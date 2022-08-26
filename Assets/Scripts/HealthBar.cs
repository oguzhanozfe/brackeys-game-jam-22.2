using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    void Start(){
        GetComponent<RectTransform>().localScale = new Vector3(0.8f, 1, 1);
    }

    void Update(){

    }
}
