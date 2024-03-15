using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipsDisabler : MonoBehaviour
{
    private int DifficultyLevel = PlayerPrefs.GetInt("Difficulty Level");
    // public List<GameObject> HiddenObjectList = new List<GameObject>();
    public Button[] HOListLabelBtns;
    // Start is called before the first frame update
    void Start()
    {
        if(DifficultyLevel == 2||DifficultyLevel == 3){
            for(int i = 0; i < HOListLabelBtns.Length; i++){
                HOListLabelBtns[i].interactable = false;
            }
        }
        else if(DifficultyLevel==1){
            for(int i = 0; i < HOListLabelBtns.Length; i++){
                HOListLabelBtns[i].interactable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
