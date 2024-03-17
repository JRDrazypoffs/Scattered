using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectArea : MonoBehaviour
{
    public Button[] buttons;
    // public GameObject[] Area;

    private void Awake(){
        int UnlockedLevel = PlayerPrefs.GetInt("Unlocked Area",1);

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
            // Area[i].GetComponent<Collider2D>().isTrigger = false;
        }

        for(int i = 0; i < UnlockedLevel; i++){
            buttons[i].interactable = true;
            // Area[i].GetComponent<Collider2D>().isTrigger = true;
        }
    }

    public void EnterArea(string AreaName){
        SceneManager.LoadScene(AreaName);
    }
}
