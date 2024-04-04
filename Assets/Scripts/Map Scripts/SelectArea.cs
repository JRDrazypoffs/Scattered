using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectArea : MonoBehaviour
{
    public Button[] buttons;
    // public GameObject[] Area;
    public static int currentLevel;
    public static int unlockedLevels;
    
    private void Awake(){
        unlockedLevels = PlayerPrefs.GetInt("Unlocked Levels",0);

        for(int i = 0; i < buttons.Length; i++){
            if(unlockedLevels >= i){
                buttons[i].interactable = true;
            }
        }
    }

    public void EnterArea(string AreaName){
        SceneManager.LoadScene(AreaName);
    }

    // please check if this works, generally if current level is higher than unlocked levels 
    // it means player has already cleared the level before and no need to show dialogue again
    public void EnterArea(string AreaName, string AreaDialogName){
        if(currentLevel>unlockedLevels){
            SceneManager.LoadScene(AreaName);
        }else{
            SceneManager.LoadScene(AreaDialogName);
        }
    }
}
