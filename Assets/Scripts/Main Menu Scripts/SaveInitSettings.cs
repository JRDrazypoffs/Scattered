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

    public GameObject EasyPanel;
    public GameObject ModeratePanel;
    public GameObject DifficultPanel;
    
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

    void Update(){
        if(difficultyDropdown.value==0){
            EasyPanel.SetActive(true);
            ModeratePanel.SetActive(false);
            DifficultPanel.SetActive(false);
        }else if(difficultyDropdown.value==1){
            EasyPanel.SetActive(false);
            ModeratePanel.SetActive(true);
            DifficultPanel.SetActive(false);
        }else{
            EasyPanel.SetActive(false);
            ModeratePanel.SetActive(false);
            DifficultPanel.SetActive(true);
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
