using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HintMeter : MonoBehaviour
{
    public float rgbVal = 0.3f;
    public float ColorTimer = 0;

    public static bool HintReady = false;
    public static bool HintUsed = false;
    
    // public Transform HintGlow; //GetComponent<ParticleSystem>().enableEmission method deprecated
    
    // Start is called before the first frame update
    void Start(){
        // HintGlow.GetComponent<ParticleSystem>().enableEmission = false;
        var HintGlow = GetComponent<ParticleSystem>();
        HintGlow.Stop();

    }

    // Update is called once per frame
    void Update(){
        ColorTimer += Time.deltaTime;

        if ((ColorTimer >= .30) && (rgbVal < 1)){ //set time to x seconds and the color is not at brightest
            rgbVal += .02f; //incrementally increase brightness
            ColorTimer = 0;
        }

        GetComponent<SpriteRenderer>().color = new Color (rgbVal,rgbVal,rgbVal);

        if(rgbVal >= 1f){
            HintReady = true;
            // HintGlow.GetComponent<ParticleSystem>().enableEmission = true;
            GetComponent<SpriteRenderer>().color = new Color(0.94f,0.78f,0.37f);//set color to mustard yellow
            var HintGlow = GetComponent<ParticleSystem>();
            HintGlow.Play();

        }
    }

    void OnMouseDown(){
        if (HintReady == true){
            HintUsed = true;
            HintReady = false;
            rgbVal = 0.3f;
            // HintGlow.GetComponent<ParticleSystem>().enableEmission = false;
            var HintGlow = GetComponent<ParticleSystem>();
            HintGlow.Stop();

        }
    }
}