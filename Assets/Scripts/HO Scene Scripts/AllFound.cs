using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllFound : MonoBehaviour
{
    // public string[] HiddenObjects;
    public List<GameObject> HiddenObjectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start(){
        
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
                UnlockNewArea();
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


