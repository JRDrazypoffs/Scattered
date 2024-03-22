using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndTitle : MonoBehaviour
{
    public AudioSource BGM;
    public GameObject EndTitlePanel;
    public GameObject CreditsBtn;
    public GameObject BackBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(BGM.isPlaying == false){
            EndTitlePanel.SetActive(true);
            CreditsBtn.SetActive(false);
            BackBtn.SetActive(false);
        }
    }
}
