using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ClickControl : MonoBehaviour
{
    public static string ObjectName;
    public GameObject ObjectNameText;
    public Transform HiddenObjectPos;
    public Transform SuccessClick;
    public AudioClip FoundSFX;
    public AudioSource FoundSound;

    

    // Start is called before the first frame update
    void Start(){
        // // This Will Configure the  AudioSource Component; 
        // // MAke Sure You added AudioSouce to death Zone;
        // GetComponent<AudioSource> ().playOnAwake = false;
		// GetComponent<AudioSource> ().clip = FoundSFX;
        // FoundSound = GetComponent<AudioSource>();
        // FoundSound.playOnAwake = false;
    }

    // // Update is called once per frame
    // void Update()
    // {}
    private void OnMouseDown(){
        // int HiddenObjectCount = 0;
        ObjectName = gameObject.name;
        Debug.Log (ObjectName);
        Destroy (gameObject);
        Destroy (ObjectNameText);
        // FoundSound.Play ();
        Instantiate(SuccessClick, HiddenObjectPos.position, SuccessClick.rotation);
    }


}
