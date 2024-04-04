using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void LoadGame(){
        SceneManager.LoadSceneAsync("Map");
    }

    public void StartNewGame(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync("Start New Game Menu");
    }

    public void LaunchInitScene(){
        SceneManager.LoadSceneAsync("Dialog Antique Store 1");
    }

    public void LoadMainMenu(){
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
