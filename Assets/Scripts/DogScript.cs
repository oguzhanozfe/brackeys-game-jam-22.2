using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script should be added to dogs, not players
// Strays have box collisions, Friends dont.

public class DogScript : MonoBehaviour
{
    public GameObject player;

    bool isFriend;
    bool hasEntered; //dogs have collisions
    bool isHit;

    public Vector3 offSet; 
    
    public int health;
    public int maxHealth;
    public int damage;

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
        isFriend = (gameObject.tag == "Friend" || CompareTag("Friend"));

        if(health>0 && isHit)
        {
            isHit = false;
            health--;
            Debug.Log(health);
        }
        else if(health <= 0)
        {
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

    
}
