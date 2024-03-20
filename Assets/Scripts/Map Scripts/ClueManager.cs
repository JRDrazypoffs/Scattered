using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public GameObject[] Clues;
    public GameObject IsEmptyText;

    private static int unlockedLevels;

    // Start is called before the first frame update
    void Start(){
        unlockedLevels = PlayerPrefs.GetInt("Unlocked Levels");
    }

    // Update is called once per frame
    void Update(){
        if(unlockedLevels>0){
            IsEmptyText.SetActive(false);
        }

        for(int i = 0; i<Clues.Length; i++){
            if(i==0 && unlockedLevels>0){
                // the first area unlocks 2 clues
                Clues[0].SetActive(true);
                Clues[1].SetActive(true);
            }
            if(i<=unlockedLevels && unlockedLevels>0){
                // the subsequent area unlocks 1 clue
                // the -1 is used to offset the index as the area unlocked hasnt goven the players any clues yet
                // then +1 due to the offset of the rules above. 
                Clues[i].SetActive(true);
            }
        }
    }
}
