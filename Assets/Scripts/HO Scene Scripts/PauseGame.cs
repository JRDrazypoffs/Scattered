using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public void PauseTheGame(){
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeTheGame(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
