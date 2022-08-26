using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour{

    void Start(){
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void setSize(float size){
        GetComponent<RectTransform>().localScale = new Vector3(size, 1, 1);
        
    }
}
