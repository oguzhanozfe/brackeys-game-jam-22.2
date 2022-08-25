using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class heroControl : MonoBehaviour
{
    [SerializeField] private float pspeed = 6.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmooth = 1000f;
    [SerializeField] private bool isGamepad;

    private CharacterController controller;

    private Vector2 movement;
    private Vector2 aim;

    private Vector3 pvelocity;

    private PlayerControls playerControls;
    private PlayerInput playerInput;


    public GameObject heartt;
    public GameObject hand;

    public bool canShoot;
    public float lastShot;
    public float cooldown;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();

        lastShot = 0;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
        Fire();                        
    }
    private void HandleInput()
    {
        movement = playerControls.Controls.Move.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();
    }
    private void HandleMovement()
    {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * pspeed);

        pvelocity.y -= gravityValue * Time.deltaTime;
        controller.Move(pvelocity * Time.deltaTime);
        
    }
    private void HandleRotation()
    {
        if (isGamepad)
        {
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * gamepadRotateSmooth);
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(aim);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
    }

    private void LookAt(Vector3 lookpoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookpoint.x, transform.position.y, lookpoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

 
    private void Fire()
    {
        if (playerControls.Controls.Fire.triggered && canShoot)
        {
            GameObject heart = Instantiate(heartt, hand.transform.position, transform.rotation);

            heart.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            heart.tag = "Heart";

            BoxCollider sc = heart.AddComponent(typeof(BoxCollider)) as BoxCollider;
            Destroy(heart, 2);
            lastShot = Time.time;
        }
        canShoot = (Time.time - lastShot > cooldown);
    }

    public void OnDeviceChange (PlayerInput pi)

    {
        isGamepad = pi.currentControlScheme.Equals("Controller") ? true : false;
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
    
        //Do the action after the delay time has finished.
    }
}

