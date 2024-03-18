using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System;

public class PlayerSettings : MonoBehaviour
{   

    [SerializeField] TMP_InputField UsernameInput;
    public TMP_Dropdown difficultyDropdown;
    public TMP_Dropdown graphicsDropdown;
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer MasterAudioMixer;

    Resolution[] resolutions;

    private float MasterVolume;
    float BGMVolume;
    float SFXVolume;
    string Username;
    int DifficultyIndex;
    int QualityIndex;
    int resolutionIndex;


    // Start is called before the first frame update
    void Start(){
        // check if user has set settings
        if(
            PlayerPrefs.HasKey("Player Pref Master Volume") &&
            PlayerPrefs.HasKey("Player Pref BGM Volume") &&
            PlayerPrefs.HasKey("Player Pref SFX Volume") &&
            PlayerPrefs.HasKey("Player Pref Username") &&
            PlayerPrefs.HasKey("Player Pref Difficulty") &&
            PlayerPrefs.HasKey("Player Pref Graphic QI") &&
            PlayerPrefs.HasKey("Player Pref Resolution Index") &&
            PlayerPrefs.HasKey("Player Pref IsFullscreen") 
        ){
            Debug.Log("you have all settings data stored");
            LoadPrefSettings();
        }else{
            Debug.Log("please set your settings");
        }

        // Resolution Setting
        resolutions = Screen.resolutions;

        // clear placeholders in resolution dropdown
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        // Processing the resolutions obtained fromd evice into arrays to display as dropdown options.
        for(int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }

        // Set Default resolution as current resolution
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // // Update is called once per frame
    // void Update(){
    // }

    public void GetUserSettings(){
        // TODO:
        // Get user settings
        // save user settings to player prefs
    }

    public void SetMasterVolume(float MasterVolume){
        // Debug.Log(MasterVolume);
        MasterAudioMixer.SetFloat("MasterVolume", MasterVolume);
        PlayerPrefs.SetFloat("Player Pref Master Volume",MasterVolume);
        PlayerPrefs.Save();
    }

    public void SetBGMVolume(float BGMVolume){
        // Debug.Log(MasterVolume);
        MasterAudioMixer.SetFloat("BGMVolume", BGMVolume);
        PlayerPrefs.SetFloat("Player Pref BGM Volume",BGMVolume);
    }

    public void SetSFXVolume(float SFXVolume){
        // Debug.Log(MasterVolume);
        MasterAudioMixer.SetFloat("SFXVolume", SFXVolume);
        PlayerPrefs.SetFloat("Player Pref SFX Volume",SFXVolume);
    }

    public void SetUsername(string UsernameInput){
        PlayerPrefs.SetString("Player Pref Username",UsernameInput);
    }

    public void SetDifficulty(int DifficultyIndex){
        PlayerPrefs.SetInt("Player Pref Difficulty",DifficultyIndex);
    }

    public void SetGraphicsQuality(int QualityIndex){
        QualitySettings.SetQualityLevel(QualityIndex);
        PlayerPrefs.SetInt("Player Pref Graphic QI",QualityIndex);
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Player Pref Resolution Index",resolutionIndex);
    }

    public void SetFullscreen(bool IsFullscreen){
        int IntIsFullscreen = 1;
        Screen.fullScreen = IsFullscreen;
        // convert bool to int cause playerpref cannot set int
        if(IsFullscreen==true){
            IntIsFullscreen = 1;
        }else{
            IntIsFullscreen = 0;
        }
        PlayerPrefs.SetInt("Player Pref IsFullscreen",IntIsFullscreen);
    }

    private void LoadPrefSettings(){
        float MasterVolume  = PlayerPrefs.GetFloat("Player Pref Master Volume");
        float BGMVolume     = PlayerPrefs.GetFloat("Player Pref BGM Volume");
        float SFXVolume     = PlayerPrefs.GetFloat("Player Pref SFX Volume");
        string Username     = PlayerPrefs.GetString("Player Pref Username");
        int DifficultyIndex = PlayerPrefs.GetInt("Player Pref Difficulty");
        int GraphicQIndex   = PlayerPrefs.GetInt("Player Pref Graphic QI");
        int ResolutionIndex = PlayerPrefs.GetInt("Player Pref Resolution Index");
        int IntIsFullscreen = PlayerPrefs.GetInt("Player Pref IsFullscreen");

        Debug.Log(MasterVolume);
        Debug.Log(BGMVolume);
        Debug.Log(SFXVolume);
        Debug.Log(Username);
        Debug.Log(DifficultyIndex);
        Debug.Log(GraphicQIndex);
        Debug.Log(ResolutionIndex);
        Debug.Log(IntIsFullscreen);

    }

    
}
