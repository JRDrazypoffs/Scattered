using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;
using TMPro;

public class SaveInitSettings : MonoBehaviour
{

    Resolution[] resolutions;

    [SerializeField] TMP_InputField UsernameInput;
    public TMP_Dropdown difficultyDropdown;
    private int TempResolutionIndex;
    
    void Start(){
        resolutions = Screen.resolutions;
        for(int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;

            if(resolutions[i].width == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height){
                TempResolutionIndex = i;
            }
        }
    }

    public void SaveInitData(){

        PlayerPrefs.SetString("Player Pref Username",UsernameInput.text);
        PlayerPrefs.SetInt("Player Pref Difficulty",difficultyDropdown.value);
        PlayerPrefs.SetInt("Player Pref Resolution Index",TempResolutionIndex);
        PlayerPrefs.SetInt("Player Pref IsFullscreen",1);
        PlayerPrefs.SetInt("Settings Has Set",1);
        PlayerPrefs.Save();
    }
}
