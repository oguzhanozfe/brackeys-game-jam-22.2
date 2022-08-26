using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
            Destroy(gameObject);
    }
}
