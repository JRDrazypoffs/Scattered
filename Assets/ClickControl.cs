using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // int HiddenObjectCount = 0;
        ObjectName = gameObject.name;
        Debug.Log (ObjectName);
        Destroy (gameObject);
        Destroy (ObjectNameText);
        // HiddenObjectCount++;

        // // If found all 10 objects
        // if(HiddenObjectCount==10){
        //     UnlockNewArea();
        // }
    }

    // public void UnlockNewArea(){
    //     if(SceneManager.GetActiveScene().buildIndex <= PlayerPrefs.GetInt("ReachedIndex")){
    //         PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1 );
    //         PlayerPrefs.SetInt("UnlockedArea", PlayerPrefs.GetInt("UnlockedArea", 1) + 1 );
    //         PlayerPrefs.Save();
    //     }
    // }
}
