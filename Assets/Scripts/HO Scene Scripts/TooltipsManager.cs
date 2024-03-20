using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipsManager : MonoBehaviour
{
    // public List<Button> HiddenObjectList = new List<Button>();//take in the buttons
    public GameObject[] ObjectDesc;//take in the desc text

    public void CloseDesc(){
        for(int i = 0; i<ObjectDesc.Length; i++){
            ObjectDesc[i].SetActive(false);
        }
    }
}
