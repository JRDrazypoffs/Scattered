using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisabler : MonoBehaviour
{
    // Cannot use get method from monobehaviour
    // TODO: find another solution for this
    // private int DifficultyLevel = PlayerPrefs.GetInt("Player Pref Difficulty");
    // public List<GameObject> HiddenObjectList = new List<GameObject>();

    public GameObject TimerUI;
    // Start is called before the first frame update
    void Start(){
        int DifficultyLevel = 2;
        if(DifficultyLevel == 0||DifficultyLevel == 1){
            TimerUI.SetActive(false);
        }
        else if(DifficultyLevel==2){
            TimerUI.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
