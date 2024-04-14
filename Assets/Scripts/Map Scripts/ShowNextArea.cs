using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNextArea : MonoBehaviour
{
    public GameObject[] BuildingBtns;
    private int CurrentLevel;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<BuildingBtns.Length;i++) {
            if(CurrentLevel-3==i){
                BuildingBtns[i].GetComponent<Animator>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLevel = PlayerPrefs.GetInt("Reached Index");

        if(CurrentLevel<4){
            BuildingBtns[0].GetComponent<Animator>().enabled = true;
        }else if(CurrentLevel > 3 && CurrentLevel < 10){
            for(int i = 0;i<7;i++) {
                if(CurrentLevel-3==i){
                    BuildingBtns[i].GetComponent<Animator>().enabled = true;
                }
            }
        }else{
            for(int i = 0;i<BuildingBtns.Length;i++) {
                if(CurrentLevel-3!=i){
                    BuildingBtns[i].GetComponent<Animator>().enabled = false;
                }
            }
        }
    }
}
