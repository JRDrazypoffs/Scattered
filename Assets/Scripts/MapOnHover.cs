using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;
using System.Reflection;

public class MapOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{   
    public GameObject Sign;
    public TMP_Text SignText;
    public Button[] Building;
    // public Animation HoverAnimation;
    public Animation SignAnimationIn;
    public Animation SignAnimationOut;


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        // if(Building.IsActive == true ){

        // }
    }

    public void OnPointerEnter(){
        // check the object
        // do the stuff
    }

    public void OnPointerEnter(PointerEventData pointerEventData){
        //Output to console the GameObject's name and the following message
        // Debug.Log("Cursor Entering " + name + " GameObject");
        // pointerEventData.pointerCurrentRaycast.GetType();
        Debug.Log("Cursor Entering " + pointerEventData.pointerCurrentRaycast.GetType() + " GameObject");

        SignAnimationIn.Play();
        // SignAnimationOut.Stop();
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData){
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        // SignAnimationIn.Stop();
        SignAnimationOut.Play();

    }
}
