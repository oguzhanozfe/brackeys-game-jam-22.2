using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    void Start(){
        RectTransform bar = transform.Find("Bar").GetComponent<RectTransform>();
        bar.sizeDelta = new Vector2(bar.sizeDelta.x, bar.sizeDelta.y * 0.5f);
    }

    void Update(){

    }
}
