using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisabler : MonoBehaviour
{

    public GameObject TimerUI;
    // Start is called before the first frame update
    void Start(){
        int DifficultyLevel = PlayerPrefs.GetInt("Player Pref Difficulty");
        if(DifficultyLevel == 0||DifficultyLevel == 1){
            TimerUI.SetActive(false);
        }
        else if(DifficultyLevel==2){
            TimerUI.SetActive(true);
        }
        
    }
}
