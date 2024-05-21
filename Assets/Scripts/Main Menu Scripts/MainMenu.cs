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
