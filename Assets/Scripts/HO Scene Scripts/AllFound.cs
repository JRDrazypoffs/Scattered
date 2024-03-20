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
                SuccessMessage.text = "<b>Congratulations</b> <color=#60B2D7><b>"+ Username + "</b></color>! \nYou have <color=green><b>completed</b></color> this level!";
            }
        }
    }

    void UnlockNewArea(){
        if(SelectArea.currentLevel == SelectArea.unlockedLevels){
            SelectArea.unlockedLevels++;
            SelectArea.currentLevel++;
            PlayerPrefs.SetInt("Current Level", SelectArea.currentLevel);
            PlayerPrefs.SetInt("Unlocked Levels", SelectArea.unlockedLevels);
            PlayerPrefs.Save();
        }
    }
}


