using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllFound : MonoBehaviour
{
    // public string[] HiddenObjects;
    public List<GameObject> HiddenObjectList = new List<GameObject>();
    public AudioSource LevelCompleteSound;
    public AudioSource BGMPlayer;

    public GameObject HintBtn;
    public GameObject Timer;
    public GameObject LevelCompletePanel;

    public TMP_Text SuccessMessage;
    private string Username;

    // Start is called before the first frame update
    void Start(){
        string TempUsername = PlayerPrefs.GetString("Player Pref Username");
        Username = TempUsername;
    }

    // Update is called once per frame
    void Update (){
        for (int i = HiddenObjectList.Count - 1; i >= 0; i--)
        {
            if (HiddenObjectList[i] == null){
                HiddenObjectList.RemoveAt(i);
            }
 
            if (HiddenObjectList.Count == 0){
                print("Area Cleared");
                Destroy(HintBtn);
                Destroy(Timer);
                BGMPlayer.Stop();
                LevelCompleteSound.Play();
                UnlockNewArea();
                LevelCompletePanel.SetActive(true);
                SuccessMessage.text = "<b>Congratulations</b> <color=#F0C75E><b>"+ Username + "</b></color>, \nyou have <color=#509D69><b>completed</b></color> this level!";
            }
        }
    }

    public void UnlockNewArea(){
        if(SceneManager.GetActiveScene().buildIndex <= PlayerPrefs.GetInt("ReachedIndex")){
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1 );
            PlayerPrefs.SetInt("UnlockedArea", PlayerPrefs.GetInt("UnlockedArea", 1) + 1 );
            PlayerPrefs.Save();
        }
        print("New Area Unlocked");
    }
}


