using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused = false;//allow other extension to other objects
    [SerializeField] GameObject PauseMenu;
    public void PauseTheGame(){
        // PauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void ResumeTheGame(){
        // PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
}
