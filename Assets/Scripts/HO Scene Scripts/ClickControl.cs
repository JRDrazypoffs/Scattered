using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ClickControl : MonoBehaviour
{
    public static string ObjectName;
    public GameObject ObjectNameText;
    public Transform HiddenObjectPos;
    public Transform SuccessClick;
    public AudioSource FoundSound;

    // Start is called before the first frame update

    private void OnMouseDown(){
        // int HiddenObjectCount = 0;
        ObjectName = gameObject.name;
        // Debug.Log (ObjectName);
        Destroy (gameObject);
        // Destroy (ObjectNameText);
        // ObjectNameText.GetComponent<Animator>().Play("DimItemLabel");
        ObjectNameText.GetComponent<Animator>().cullingMode=0;
        ObjectNameText.GetComponent<Button>().enabled=false;
        FoundSound.Play ();
        Instantiate(SuccessClick, HiddenObjectPos.position, SuccessClick.rotation);
    }

}
