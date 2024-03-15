using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;

public class PlayerSettings : MonoBehaviour
{
    public AudioMixer MasterAudioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start(){
        resolutions = Screen.resolutions;

        // clear placeholders in resolution dropdown
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for(int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
    }

    // // Update is called once per frame
    // void Update(){
    // }

    public void SetMasterVolume(float MasterVolume){
        // Debug.Log(MasterVolume);
        MasterAudioMixer.SetFloat("MasterVolume", MasterVolume);
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


}
