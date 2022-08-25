using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script should be added to dogs, not players

public class DogScript : MonoBehaviour
{
    public GameObject player;

    bool isFriend;

    bool hasEntered; //dogs have collisions

    public Vector3 offSet; 

    // Start is called before the first frame update
    void Start()
    {
        isFriend = (gameObject.tag == "Friend");
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
