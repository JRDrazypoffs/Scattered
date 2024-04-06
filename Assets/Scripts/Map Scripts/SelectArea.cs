using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectArea : MonoBehaviour
{
    public Button[] buttons;
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

    // Trying to figure out how to check the cleared levels commented codes cause not working QwQ
    public void EnterDialogue(string AreaName){
        SceneManager.LoadScene("Dialog "+AreaName);
    }
}
