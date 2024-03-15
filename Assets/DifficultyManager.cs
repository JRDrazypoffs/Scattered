using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private int DifficultyLevel = PlayerPrefs.GetInt("Difficulty Level");
    // Level Guide: 1 Easy, 2 Moderate, 3 Hard

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if(DifficultyLevel == 1){
            // Enable Tooltip
            // Disable Timer
        }
        else if(DifficultyLevel == 2){
            // Disable Tooltip
            // Disable Timer
        }
        else{
            // Disable Tooltip
            // Enable Timer
        }
    }
    
}
