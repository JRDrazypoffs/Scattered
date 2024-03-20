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
}
