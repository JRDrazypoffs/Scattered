using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;
using TMPro;

public class SaveInitSettings : MonoBehaviour
{

    Resolution[] resolutionsStart;

    [SerializeField] TMP_InputField UsernameInput;
    public TMP_Dropdown difficultyDropdown;
    private int TempResolutionIndex;

    public GameObject EasyPanel;
    public GameObject ModeratePanel;
    public GameObject DifficultPanel;

    // Set warning text variable
    public Button SaveBtn;
    public TMP_Text WarningTextField;
    private string UsernameName;
    private string WarningText;

    // check for previously saved settings
    private static bool SettingsInitWasSet;
    
    void Start(){
        resolutionsStart = Screen.resolutions;
        for(int i = 0; i < resolutionsStart.Length; i++){
            // string option = resolutions[i].width + " x " + resolutions[i].height;

            if(resolutionsStart[i].width == Screen.currentResolution.width && 
            resolutionsStart[i].height == Screen.currentResolution.height){
                TempResolutionIndex = i;
            }
        }

        SettingsInitWasSet = PlayerPrefs.HasKey("Settings Init Was Set");
    }

    void Update(){
        WarningTextField.text = WarningText;
        UsernameName = UsernameInput.text;
        ValidateUsername();

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
        
        if (SettingsInitWasSet==false){
            // preset settings if no settings was initially set
            PlayerPrefs.SetString("Player Pref Username",UsernameInput.text);
            PlayerPrefs.SetInt("Player Pref Difficulty",difficultyDropdown.value);
            PlayerPrefs.SetInt("Player Pref Resolution Index",TempResolutionIndex);
            PlayerPrefs.SetInt("Player Pref IsFullscreen",1);
        }else{
            PlayerPrefs.SetString("Player Pref Username",UsernameInput.text);
            PlayerPrefs.SetInt("Player Pref Difficulty",difficultyDropdown.value);
            PlayerPrefs.SetFloat("Player Pref Master Volume",PlayerPrefs.GetFloat("Player Pref Master Volume"));
            PlayerPrefs.SetFloat("Player Pref BGM Volume",PlayerPrefs.GetFloat("Player Pref BGM Volume"));
            PlayerPrefs.SetFloat("Player Pref SFX Volume",PlayerPrefs.GetFloat("Player Pref SFX Volume"));
            PlayerPrefs.SetInt("Player Pref Graphic QI",PlayerPrefs.GetInt("Player Pref Graphic QI"));
            PlayerPrefs.SetInt("Player Pref Resolution Index",PlayerPrefs.GetInt("Player Pref Resolution Index"));
            PlayerPrefs.SetInt("Player Pref IsFullscreen",PlayerPrefs.GetInt("Player Pref IsFullscreen"));
        }

        PlayerPrefs.SetInt("Settings Has Set",1);
        PlayerPrefs.Save();
    }

    void ValidateUsername(){
       WarningText="";

        // Define the regex pattern
        string pattern = @"^[a-zA-Z0-9@\-_\. ]+$";                  // check if alphanumerals, with @ . - _ characters
        string pattern2 = @"^[0-9@\-_\. ]+$";                       // check if no alphabets and is only 1 character
        string pattern3 = @"^[^a-zA-Z]*([a-zA-Z][^a-zA-Z]*){0,1}$"; // Username must contain one alphabetic characters or fewer


        // Use the Matches method to find matches in the input string
        bool isMatch = Regex.IsMatch(UsernameName, pattern);
        bool isMatch2 = Regex.IsMatch(UsernameName, pattern2);
        bool isMatch3 = Regex.IsMatch(UsernameName, pattern3);
        

        if(UsernameName == ""){
            WarningText="Username is empty!";
            SaveBtn.interactable = false;
        }else if( !isMatch ){
            WarningText = "Username contains illegal characters!";
            SaveBtn.interactable = false;
        }else if(isMatch2||isMatch3){
            WarningText="Enter a valid name!";
            SaveBtn.interactable = false;
        }else{
            WarningText = "";
            SaveBtn.interactable = true;
        }
    }
}
