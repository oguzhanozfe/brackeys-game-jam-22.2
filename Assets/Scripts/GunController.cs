using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring = false;

    public float bulletSpeed;
    public float speed = 10.0f;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    public GameObject heart;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                heart.AddComponent<Rigidbody>();
                Rigidbody rb = Instantiate(heart.GetComponent<Rigidbody>(), firePoint.position, firePoint.rotation);
                rb.velocity = transform.forward*5f;
            }
        else
        {
            shotCounter = 0;
        }
        
        }
    }
}