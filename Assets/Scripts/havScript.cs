using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);

        if(col.tag == "Player" || col.tag == "Heart" )
            Destroy(gameObject);
    }
}
