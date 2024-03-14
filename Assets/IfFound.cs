using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IfFound : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start(){   
    // }

    // Update is called once per frame
    // void Update(){
    // }
    public static string ObjectName;
    public GameObject ObjectNameText;

    void Update(){
        CheckAllFOundObject();
    }

    // public Button[] HiddenObjects;
    // public Button[] HiddenObjectLabels;

    public void OnButtonClick(){
        ObjectName = gameObject.name;
        UnityEngine.Debug.Log (ObjectName);
        Destroy (gameObject);
        Destroy (ObjectNameText);
    }
    public void CheckAllFOundObject(){
        int FoundObjects = 0;

        // for(int i = 0; i < HiddenObjects.Length; i++){
        //     if (HiddenObjects[i].interactable == false){
        //         Destroy(HiddenObjectLabels[i]);
        //         FoundObjects++;
        //     }
        // }

        if(FoundObjects==10){
            UnlockNewArea();
        }
    }

    public void UnlockNewArea(){
        if(SceneManager.GetActiveScene().buildIndex <= PlayerPrefs.GetInt("ReachedIndex")){
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1 );
            PlayerPrefs.SetInt("UnlockedArea", PlayerPrefs.GetInt("UnlockedArea", 1) + 1 );
            PlayerPrefs.Save();
        }
    }

}
