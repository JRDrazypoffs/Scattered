using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    public void LoadGame(){
        SceneManager.LoadSceneAsync("Map");
    }

    public void StartNewGame(){
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("Settings Has Set");
        PlayerPrefs.DeleteKey("Unlocked Levels");
        PlayerPrefs.DeleteKey("Reached Index");
        PlayerPrefs.DeleteKey("Player Pref First Clear Date");
        SceneManager.LoadSceneAsync("Start New Game Menu");
    }

    public void LaunchInitScene(){
        SceneManager.LoadSceneAsync("Dialog Antique Store");
    }

    public void LoadMainMenu(){
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
