using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopControllerNoXtra : MonoBehaviour
{

    public GameObject BubbleItem;
    public GameObject PanelItem;
    // public GameObject OtherPanelItem;
    public Animator popAnimator;
    public AudioSource PopSound;

    public static int SoundTrigger = 0;

    // Start is called before the first frame update
    void Start(){
        // OtherPanelItem.SetActive(false);
        SoundTrigger = 0;
    }

    // Update is called once per frame
    void Update(){
        if(PanelItem.activeSelf == true){
            // use this silly method to stop the system from playing the sfx in infinite loop until triggered
            if(SoundTrigger == 1000000){
                SoundTrigger = 0;
            }else{
                SoundTrigger++;
            }
        }else{
            SoundTrigger = 0;
        }
        
        // let sfx audio only play once
        if(SoundTrigger==1){
            PopSound.Play();
            popAnimator.Play("PopAnimation");
        }
    }
}
