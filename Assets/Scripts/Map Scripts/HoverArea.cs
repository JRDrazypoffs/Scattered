using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HoverArea1 : MonoBehaviour
{
    public GameObject AreaLabel;
    public GameObject Sign;
    public Animator signAnimator;

    public AudioSource PopSound;

    public static int SoundTrigger = 0;

    // SFXPlayOnce sfxPlayOnce;//DIdnt behave as intended SMH
    // private void Awake(){
    //     sfxPlayOnce = GameObject.FindGameObjectWithTag("Audio").GetComponent<SFXPlayOnce>();
    // }


    // This Script uses sprite data not UI button data
    public void Start(){
        AreaLabel.SetActive(false);
        Sign.SetActive(false);
    }

    // public void Update(){
    // }

    public void OnMouseOver(){
        AreaLabel.SetActive(true);
        Sign.SetActive(true);
        signAnimator.Play("SignAnimationIn");

        // sfxPlayOnce.PlaySFX(sfxPlayOnce.PopSFX); >:( behaves weirdly SMH

        // use this silly method to stop the system from playing the sfx in infinite loop until triggered
        SoundTrigger++;
        if(SoundTrigger==10000){
            SoundTrigger=0;
        }

        // let sfx audio only play once
        if(SoundTrigger==1){
            PopSound.Play();
        }
    }



    public void OnMouseExit(){
        // signAnimator.Play("SignAnimationOut");
        Sign.SetActive(false);
        AreaLabel.SetActive(false);
        PopSound.Stop();
        SoundTrigger=0;

    }

    // Keep for reference, the Map uses the UI buttons layered over the sprites.
    // Sprites are used to use the on mouse over function for the sign animation.
    
    // public void OnMouseDown(){
    //     // EnterArea(AreaName);
    // }
    // public void EnterArea(string AreaName){
    //     SceneManager.LoadScene(AreaName);
    // }

}
