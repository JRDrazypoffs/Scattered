using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private int DifficultyLevel = PlayerPrefs.GetInt("Difficulty Level");
    // Level Guide: 0 Easy, 1 Moderate, 2 Hard based on dropdown array

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if(DifficultyLevel == 0){
            // Enable Tooltip
            // Disable Timer
        }
        else if(DifficultyLevel == 1){
            // Disable Tooltip
            // Disable Timer
        }
        else{
            // Disable Tooltip
            // Enable Timer
        }
    }
    
}
