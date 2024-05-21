using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGChanger : MonoBehaviour
{
    public GameObject SearchBG;
    public GameObject HugBG;
    public GameObject Badge;

    private int CurrentLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLevel = PlayerPrefs.GetInt("Reached Index");
        ChangeBG();
    }

    void ChangeBG(){
        if(CurrentLevel >= 10 ){
            SearchBG.SetActive(false);
            HugBG.SetActive(true);
            Badge.SetActive(true);
        }else{
            SearchBG.SetActive(true);
            HugBG.SetActive(false);
            Badge.SetActive(false);
        }
    }
}
