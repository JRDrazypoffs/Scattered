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

    private float TempMasterVolume;
    private float TempBGMVolume;
    private float TempSFXVolume;
    private int TempDifficultyIndex;
    private int TempQualityIndex;
    private int TempResolutionIndex;
    private int TempIsFullscreen;

    // Start is called before the first frame update
    void Start(){
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

        
        // check if user has set settings
        if(PlayerPrefs.HasKey("Settings Has Set")){
            Debug.Log("you have all settings data stored");
            LoadData();
        }else{
            Debug.Log("please set your settings");
        }

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
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            // Allow user edit field
            resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            TempResolutionIndex = resolutionIndex;
            // change the value when value changed
            resolutionDropdown.value = TempResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }else{
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            TempResolutionIndex = resolutionIndex;
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
    }

    private void LoadData(){
        bool toggleState;
        string Username     = PlayerPrefs.GetString("Player Pref Username");
        UsernameInput.text = Username;

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

        // Debug.Log("Master Vol: "+TempMasterVolume);
        // Debug.Log("BGM Vol: "+TempBGMVolume);
        // Debug.Log("SFX Vol: "+TempSFXVolume);
        // Debug.Log("Username: "+Username);
        // Debug.Log("Difficulty Index: "+TempDifficultyIndex);
        // Debug.Log("Graphic Index: "+TempQualityIndex);
        // Debug.Log("Resolution Index: "+TempResolutionIndex);
        // Debug.Log("Fullscreen: "+TempIsFullscreen);

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
