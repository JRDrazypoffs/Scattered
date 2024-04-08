using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System;
using Unity.Mathematics;

public class PlayerSettings : MonoBehaviour
{   

    [SerializeField] TMP_InputField UsernameInput;
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public TMP_Dropdown difficultyDropdown;
    public TMP_Dropdown graphicsDropdown;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    public AudioMixer MasterAudioMixer;

    Resolution[] resolutions;

    // Temporary variables. Used when getting new input
    // Didnt use this for the back button cause it might hold diffrent information when user clicks back btn.
    private string TempUsername;
    private float TempMasterVolume;
    private float TempBGMVolume;
    private float TempSFXVolume;
    private int TempDifficultyIndex;
    private int TempQualityIndex;
    private int TempResolutionIndex;
    private int TempIsFullscreen;

    // Buffer variables
    // to collect the values from player prefs.
    private string BufferUsername;
    private float BufferMasterVolume;
    private float BufferBGMVolume;
    private float BufferSFXVolume;
    private int BufferDifficultyIndex;
    private int BufferQualityIndex;
    private int BufferResolutionIndex;
    private int BufferIsFullscreen;

    // Set warning text variable
    public Button SaveBtn;
    public TMP_Text WarningTextField;
    private string UsernameName;
    private string WarningText;

    // Start is called before the first frame update
    void Start(){

        // Resolution Setting
        resolutions = Screen.resolutions;

        // clear placeholders in resolution dropdown
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        // set buffer to cache previous save data to save if player clicks back
        BufferUsername        = PlayerPrefs.GetString("Player Pref Username");
        BufferMasterVolume    = PlayerPrefs.GetFloat("Player Pref Master Volume");
        BufferBGMVolume       = PlayerPrefs.GetFloat("Player Pref BGM Volume");
        BufferSFXVolume       = PlayerPrefs.GetFloat("Player Pref SFX Volume");
        BufferDifficultyIndex = PlayerPrefs.GetInt("Player Pref Difficulty");
        BufferQualityIndex    = PlayerPrefs.GetInt("Player Pref Graphic QI");
        BufferResolutionIndex = PlayerPrefs.GetInt("Player Pref Resolution Index");
        BufferIsFullscreen    = PlayerPrefs.GetInt("Player Pref IsFullscreen");
        
        // Processing the resolutions obtained from device into arrays to display as dropdown options.
        for(int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        // this solution  for some reason cause the dropdown to become bugged
        // options = options.Distinct().ToList();//remove duplicate resolutions
        resolutionDropdown.AddOptions(options);
        
        // check if user has set settings
        if(PlayerPrefs.HasKey("Settings Has Set")){
            Debug.Log("you have all settings data stored");
            LoadData();
        }else{
            for(int i = 0; i < resolutions.Length; i++){
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if(resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height){
                    currentResolutionIndex = i;
                }
            }
            // Set Default resolution as current resolution
            // this solution for some reason cause the dropdown to become bugged
            // options = options.Distinct().ToList();//remove duplicate resolutions
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();

            Debug.Log("please set your settings");
        }
    }

    void Update(){
        WarningTextField.text = WarningText;
        UsernameName = UsernameInput.text;
        ValidateUsername();
    }

    public void SetMasterVolume(float MasterVolume){
        if (PlayerPrefs.HasKey("Settings Has Set")){
            // preset field
            masterSlider.value = TempMasterVolume;
            MasterAudioMixer.SetFloat("MasterVolume", TempMasterVolume);
            // allow edit
            MasterAudioMixer.SetFloat("MasterVolume", MasterVolume);
            TempMasterVolume = MasterVolume;
        }else{
            MasterAudioMixer.SetFloat("MasterVolume", MasterVolume);
            TempMasterVolume = MasterVolume;
        }
    }

    public void SetBGMVolume(float BGMVolume){
        if (PlayerPrefs.HasKey("Settings Has Set")){
            // preset field
            bgmSlider.value = TempBGMVolume;
            MasterAudioMixer.SetFloat("BGMVolume", TempBGMVolume);
            // allow edit
            MasterAudioMixer.SetFloat("BGMVolume", BGMVolume);
            TempBGMVolume = BGMVolume;
        }else{
            MasterAudioMixer.SetFloat("BGMVolume", BGMVolume);
            TempBGMVolume = BGMVolume;
        }
    }

    public void SetSFXVolume(float SFXVolume){
        if (PlayerPrefs.HasKey("Settings Has Set")){
            // preset field
            sfxSlider.value = TempSFXVolume;
            MasterAudioMixer.SetFloat("SFXVolume", TempSFXVolume);
            // allow edit
            MasterAudioMixer.SetFloat("SFXVolume", SFXVolume);
            TempSFXVolume = SFXVolume;
        }else{
            MasterAudioMixer.SetFloat("SFXVolume", SFXVolume);
            TempSFXVolume = SFXVolume;
        }
    }

    public void SetDifficulty(int DifficultyIndex){
        if (PlayerPrefs.HasKey("Settings Has Set")){
            // preset field
            difficultyDropdown.value = TempDifficultyIndex;
            // allow edit
            TempDifficultyIndex = DifficultyIndex;
            // change the value when value changed
            difficultyDropdown.value = TempDifficultyIndex;
            difficultyDropdown.RefreshShownValue();
        }else{
            TempDifficultyIndex = DifficultyIndex;
        }
    }

    public void SetGraphicsQuality(int QualityIndex){
        if (PlayerPrefs.HasKey("Settings Has Set")){
            // preset field
            graphicsDropdown.value = TempQualityIndex;
            // allow edit
            QualitySettings.SetQualityLevel(QualityIndex);
            TempQualityIndex = QualityIndex;
            // change the value when value changed
            graphicsDropdown.value = TempQualityIndex;
            graphicsDropdown.RefreshShownValue();
        }else{
            QualitySettings.SetQualityLevel(QualityIndex);
            TempQualityIndex = QualityIndex;
        }
    }

    public void SetResolution(int resolutionIndex){
        if (PlayerPrefs.HasKey("Settings Has Set")){            
            // preset to previous saved field
            resolutionDropdown.value = TempResolutionIndex;
            // Resolution resolution = resolutions[resolutionIndex];
            // Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            // Allow user edit field
            // resolution = resolutions[resolutionIndex];
            // Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
            TempResolutionIndex = resolutionIndex;

            // change the value when value changed
            resolutionDropdown.value = TempResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }else{
            // Resolution resolution = resolutions[resolutionIndex];
            // Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            TempResolutionIndex = resolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    public void SetFullscreen(bool IsFullscreen){
        if (PlayerPrefs.HasKey("Settings Has Set")){
            // preset to previous saved field
            if(TempIsFullscreen == 1){
                Screen.fullScreen = true;
            }else{
                Screen.fullScreen = false;
            }
            // Allow user edit field
            Screen.fullScreen = IsFullscreen;
            // convert bool to int cause playerpref cannot set int
            if(IsFullscreen==true){
                TempIsFullscreen = 1;
            }else{
                TempIsFullscreen = 0;
            }
        }else{
            Screen.fullScreen = IsFullscreen;
            // convert bool to int cause playerpref cannot set int
            if(IsFullscreen==true){
                TempIsFullscreen = 1;
            }else{
                TempIsFullscreen = 0;
            }
        }
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

    public void SaveData(){

        PlayerPrefs.SetString("Player Pref Username",UsernameInput.text);
        PlayerPrefs.SetFloat("Player Pref Master Volume",TempMasterVolume);
        PlayerPrefs.SetFloat("Player Pref BGM Volume",TempBGMVolume);
        PlayerPrefs.SetFloat("Player Pref SFX Volume",TempSFXVolume);
        PlayerPrefs.SetInt("Player Pref Difficulty",TempDifficultyIndex);
        PlayerPrefs.SetInt("Player Pref Graphic QI",TempQualityIndex);
        PlayerPrefs.SetInt("Player Pref Resolution Index",TempResolutionIndex);
        PlayerPrefs.SetInt("Player Pref IsFullscreen",TempIsFullscreen);
        PlayerPrefs.SetInt("Settings Has Set",1);
        PlayerPrefs.Save();

        // Initialise all temp variables after save
        TempMasterVolume = 0;
        TempBGMVolume = 0;
        TempSFXVolume = 0;
        TempDifficultyIndex = 0;
        TempQualityIndex = 0;
        TempResolutionIndex = 0;
        TempIsFullscreen = 0;
        
        Start();
    }

    public void RevertData(){
        // if player already clicked save then dont save the buffer values 
        // when they open the save and clicked back
        PlayerPrefs.SetString("Player Pref Username",BufferUsername);
        PlayerPrefs.SetFloat("Player Pref Master Volume",BufferMasterVolume);
        PlayerPrefs.SetFloat("Player Pref BGM Volume",BufferBGMVolume);
        PlayerPrefs.SetFloat("Player Pref SFX Volume",BufferSFXVolume);
        PlayerPrefs.SetInt("Player Pref Difficulty",BufferDifficultyIndex);
        PlayerPrefs.SetInt("Player Pref Graphic QI",BufferQualityIndex);
        PlayerPrefs.SetInt("Player Pref Resolution Index",BufferResolutionIndex);
        PlayerPrefs.SetInt("Player Pref IsFullscreen",BufferIsFullscreen);
        PlayerPrefs.SetInt("Settings Has Set",1);
        PlayerPrefs.Save();

        Start();
    }

    private void LoadData(){
        bool toggleState;
        TempUsername     = PlayerPrefs.GetString("Player Pref Username");
        UsernameInput.text = TempUsername;

        TempMasterVolume    = PlayerPrefs.GetFloat("Player Pref Master Volume");
        TempBGMVolume       = PlayerPrefs.GetFloat("Player Pref BGM Volume");
        TempSFXVolume       = PlayerPrefs.GetFloat("Player Pref SFX Volume");
        TempDifficultyIndex = PlayerPrefs.GetInt("Player Pref Difficulty");
        TempQualityIndex    = PlayerPrefs.GetInt("Player Pref Graphic QI");
        TempResolutionIndex = PlayerPrefs.GetInt("Player Pref Resolution Index");
        TempIsFullscreen    = PlayerPrefs.GetInt("Player Pref IsFullscreen");

        if(TempIsFullscreen == 1){
            toggleState=true;
        }else{
            toggleState=false;
        }

        SetMasterVolume(TempMasterVolume);
        SetBGMVolume(TempBGMVolume);
        SetSFXVolume(TempSFXVolume);
        SetDifficulty(TempDifficultyIndex);
        SetGraphicsQuality(TempQualityIndex);
        SetResolution(TempResolutionIndex);
        SetFullscreen(toggleState);
    }

    public void DeleteData(){
        PlayerPrefs.DeleteAll();
    }
    
}
