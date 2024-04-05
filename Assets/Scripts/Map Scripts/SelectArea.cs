using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectArea : MonoBehaviour
{
    public Button[] buttons;
    // public GameObject[] Area;
    public static int currentLevel;
    public static int unlockedLevels;
    public static int clearedLevels=-1;
    [SerializeField] bool[] clearedIndex;
    
    private void Awake(){
        unlockedLevels = PlayerPrefs.GetInt("Unlocked Levels",0);


        for(int i = 0; i < buttons.Length; i++){
            if(unlockedLevels >= i){
                buttons[i].interactable = true;
                // if(i>0){
                //     clearedIndex[i-1] = true;
                // }else{
                //     clearedIndex[i] = false;
                // }
                
            }
        }
    }

    public void EnterArea(string AreaName){
        SceneManager.LoadScene(AreaName);
    }

    // Trying to figure out how to check the cleared levels commented codes cause not working QwQ
    public void EnterDialogue(string AreaName){

        if(clearedLevels == 6){
            SceneManager.LoadScene(AreaName);
        }else{
            SceneManager.LoadScene("Dialog "+AreaName);
        }

        // if(clearedIndex.Any(n => n == clearedLevels)){
        //     SceneManager.LoadScene(AreaName);
        // }else{
        //     SceneManager.LoadScene("Dialog "+AreaName);
        // }

        // for(int i = 0; i < buttons.Length; i++){
        //     if( i < unlockedLevels){
        //         SceneManager.LoadScene(AreaName);
        //         // break;
        //     }else{
        //         SceneManager.LoadScene("Dialog "+AreaName);
        //     }
        // }

        // for(int i = 0; i < clearedIndex.Length; i++){
        //     if( clearedIndex[i]==true && i==clearedLevels){
        //         SceneManager.LoadScene(AreaName);
        //     }else{
        //         SceneManager.LoadScene("Dialog "+AreaName);
        //     }
        // }

        
    }
}
