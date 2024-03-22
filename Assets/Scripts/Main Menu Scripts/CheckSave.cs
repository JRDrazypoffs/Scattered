using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckSave : MonoBehaviour
{
    private static bool SettingsHasSet;
    public GameObject SaveAvailableWarningPanel;
    public AudioSource BGM;
    public AudioSource WarningSound;
    public Button LoadGameBtn;
    public Button SettingsBtn;

    private static int SoundTrigger = 0;

    // Start is called before the first frame update
    void Start(){
        SoundTrigger=0;
        SettingsHasSet = PlayerPrefs.HasKey("Settings Has Set");

        if(SettingsHasSet==true){
            LoadGameBtn.interactable = true;
            SettingsBtn.interactable = true;
        }else{
            LoadGameBtn.interactable = false;
            SettingsBtn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update(){
    }

    public void CheckIfExistSave(){

        if(SettingsHasSet==true){
            BGM.Pause();
            if(SoundTrigger == 1000000){
                SoundTrigger = 0;
            }else{
                SoundTrigger++;
            }
            SaveAvailableWarningPanel.SetActive(true);
        }else{
            PlayerPrefs.DeleteAll();
            SceneManager.LoadSceneAsync("Start New Game Menu");
        }

        if(SoundTrigger == 1){
            WarningSound.Play();
        }
    }

    public void ResetSoundTrigger(){
        SoundTrigger=0;
    }

    public void ResumeBGM(){
        BGM.UnPause();
    }
}
