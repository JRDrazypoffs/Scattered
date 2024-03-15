using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectArea : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {}
    // // Update is called once per frame
    // void Update()
    // {}

    public Button[] buttons;

    private void Awake(){
        int UnlockedLevel = PlayerPrefs.GetInt("Unlocked Area",1);

        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }

        for(int i = 0; i < UnlockedLevel; i++){
            buttons[i].interactable = true;
        }
    }

    public void EnterArea(string AreaName){
        SceneManager.LoadScene(AreaName);
    }
}
