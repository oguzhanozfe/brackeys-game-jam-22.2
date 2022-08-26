using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script should be added to dogs, not players
// Strays have box collisions, Friends dont.

public class DogScript : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public GameObject border;


    public GameObject player;

    bool canHav = true;
    bool isFriend;
    bool hasEntered; //dogs have collisions
    bool isHit;

    double havCooldown = .5;
    double lastShot = 0;

    public Vector3 offSet; 
    
    public float health;
    public float maxHealth;
    public double damage;
    public float HSize;

    public GameObject HavBullet;

    // Start is called before the first frame update
    void Start()
    {

        if(gameObject.tag == "Stray")
        {
            gameObject.AddComponent<BoxCollider>().isTrigger = true;
            health = maxHealth;
        }
    }

    void Update()
    {
        havCooldown = Random.Range(2f, 8f);

        isFriend = (gameObject.tag == "Friend" || CompareTag("Friend"));
        

        if(health>0 && isHit)
        {
            isHit = false;
            health--;
            healthBar.setSize(health/10);
            Debug.Log(health);
        }
        else if(health <= 0)
        {
            Destroy(border);
            gameObject.tag = "Friend";
        }


        transform.LookAt(player.transform);
        //              MOVING
        if (isFriend && !hasEntered)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offSet, Time.deltaTime * 5 );
        }
        if(hasEntered)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * .001f );            
        }

        //Shoot
        if(!isFriend)
        {
            Hav();
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            hasEntered = true;
        }

        if(col.tag == "Heart" && gameObject.tag == "Stray" && col is BoxCollider)
        {
            isHit = true;
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if(col.name == "Player")
        {
            hasEntered = false;
        }
    }

    void Hav()
    {
        if(canHav)
        {
            GameObject havBullet = Instantiate(HavBullet, transform.position, transform.rotation);

            havBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            havBullet.tag = "HavHav";
            SphereCollider sc = havBullet.AddComponent(typeof(SphereCollider)) as SphereCollider;
            sc.isTrigger = true;
            Destroy(havBullet, 2f);
            lastShot = Time.time;
        }
        canHav = (Time.time - lastShot > havCooldown);
        Debug.Log(havCooldown); 
    }

    
}
