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

    public Vector3 offSet; 
    
    public int health;
    public int maxHealth;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        isFriend = (gameObject.tag == "Friend");

        if(gameObject.tag == "Stray")
        {
            gameObject.AddComponent<BoxCollider>().isTrigger = true;
        }
    }

    void Update()
    {
        transform.LookAt(player.transform);
        
        if (isFriend && !hasEntered)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offSet, Time.deltaTime * 5 );
        }

        if(hasEntered)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * .001f );            
        }

        if(gameObject.tag == "Friend")
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            hasEntered = true;
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
