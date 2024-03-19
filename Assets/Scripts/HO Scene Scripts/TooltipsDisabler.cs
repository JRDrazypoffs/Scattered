using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipsDisabler : MonoBehaviour
{
    
    public Button[] HOListLabelBtns;
    // Start is called before the first frame update
    void Start()
    {
        int DifficultyLevel = PlayerPrefs.GetInt("Player Pref Difficulty");
        if(DifficultyLevel == 1||DifficultyLevel == 2){
            for(int i = 0; i < HOListLabelBtns.Length; i++){
                HOListLabelBtns[i].interactable = false;
            }
        }
        else if(DifficultyLevel==0){
            for(int i = 0; i < HOListLabelBtns.Length; i++){
                HOListLabelBtns[i].interactable = true;
            }
        }
    }
    
}
