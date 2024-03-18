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


    // public string AreaName;

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

    // public void OnMouseDown(){
    //     // EnterArea(AreaName);
    // }
    
    // public void EnterArea(string AreaName){
    //     SceneManager.LoadScene(AreaName);
    // }

    // private IEnumerator DelayText(){
    //     //set delay time
    //     yield return  new WaitForSeconds(0.2f);
    //     AreaLabel.SetActive(false);
    // }
}
