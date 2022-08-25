using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if( (col.tag == "Stray") && (col is BoxCollider) )
        {
//            Debug.Log(col.gameObject.name + "Hit");
            Destroy(gameObject);
        }
    }
}
