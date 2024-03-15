using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintMeter : MonoBehaviour
{
    public float rgbVal = 0.5f;
    public float ColorTimer = 0;

    public static bool HintReady = false;
    public static bool HintUsed = false;
    
    public Transform HintGlow;

    // Start is called before the first frame update
    void Start(){
        HintGlow.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update(){
        ColorTimer += Time.deltaTime;

        if ((ColorTimer >= .5) && (rgbVal < 1)){
            rgbVal += .05f;
            ColorTimer = 0;
        }

        GetComponent<SpriteRenderer>().color = new Color (rgbVal,rgbVal,rgbVal);

        if(rgbVal >= 1f){
            HintReady = true;
            HintGlow.GetComponent<ParticleSystem>().enableEmission = true;

        }
    }

    void OnMouseDown(){
        if (HintReady == true){
            HintUsed = true;
            HintReady =false;
            rgbVal = 0.5f;
            HintGlow.GetComponent<ParticleSystem>().enableEmission = false;

        }
    }
}
