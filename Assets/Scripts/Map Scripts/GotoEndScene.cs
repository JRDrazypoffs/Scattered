using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoEndScene : MonoBehaviour
{
    // private static int LevelsUnlocked;

    public GameObject LastClueDialog;
    public GameObject ContinueBtn;
    // Start is called before the first frame update
    void Start(){
        // LevelsUnlocked = PlayerPrefs.GetInt("Unlocked Levels");
        
    }

    // Update is called once per frame
    void Update(){
        if(LastClueDialog.activeSelf==true){
            ContinueBtn.SetActive(true);
        }
    }

    public void TriggerEndSequence(){
        SceneManager.LoadSceneAsync("Ending Sequence");
    }
}
