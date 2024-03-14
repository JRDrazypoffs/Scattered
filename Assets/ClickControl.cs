using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickControl : MonoBehaviour
{
    public static string ObjectName;
    public GameObject ObjectNameText;

    // // Start is called before the first frame update
    // void Start()
    // {}

    // // Update is called once per frame
    // void Update()
    // {}

    private void OnMouseDown(){
        ObjectName = gameObject.name;
        // UnityEngine.Debug.Log (ObjectName);
        Destroy (gameObject);
        Destroy (ObjectNameText);
        
    }
    
}
