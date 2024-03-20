using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTooltipsManager : MonoBehaviour
{
    // public List<Button> HiddenObjectList = new List<Button>();//take in the buttons
    public GameObject[] ClueDesc;//take in the desc text
    public GameObject[] ClueBubble;

    public void CloseDesc(){
        for(int i = 0; i<ClueDesc.Length; i++){
            ClueDesc[i].SetActive(false);
            ClueBubble[i].SetActive(false);
        }
    }

    public void ResetCounterBuffer(){
        CluePopController.SoundTrigger = 0;
    }
}
