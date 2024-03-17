using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class PlayerSettings : MonoBehaviour
{   

    [SerializeField] TMP_InputField UsernameInput;
    public TMP_Dropdown difficultyDropdown;
    public TMP_Dropdown graphicsDropdown;
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer MasterAudioMixer;

    Resolution[] resolutions;

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
    }

    // // Update is called once per frame
    // void Update(){
    // }

    public void GetUserSettings(){
        // TODO:
        // Get user settings
        // save user settings to player prefs
    }

    public void SetUserSettings(){
        // TODO:
        // Get user settings from player prefs
        // set user settings as default value in inputs
        int DifficultyIndex = 1;//for testing
        PlayerPrefs.SetInt("Player Pref Difficulty",DifficultyIndex);

    }

    public void SetMasterVolume(float MasterVolume){
        // Debug.Log(MasterVolume);
        MasterAudioMixer.SetFloat("MasterVolume", MasterVolume);
        PlayerPrefs.SetFloat("Player Pref Volume",MasterVolume);
        // TODO: move this to onsubmit afterwards!
        PlayerPrefs.Save();
    }

    // TODO: Set Separate Volumes for BGM and SFX

    // public void SetBGMVolume(float BGMVolume){
    //     // Debug.Log(MasterVolume);
    //     MasterAudioMixer.SetFloat("BGMVolume", BGMVolume);
    // }

    // public void SetSFXVolume(float SFXVolume){
    //     // Debug.Log(MasterVolume);
    //     MasterAudioMixer.SetFloat("SFXVolume", SFXVolume);
    // }

    public void SetGraphicsQuality(int QualityIndex){
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullscreen(bool IsFullscreen){
        Screen.fullScreen = IsFullscreen;
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    
}
