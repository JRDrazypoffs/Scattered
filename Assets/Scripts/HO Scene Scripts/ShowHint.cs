using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class ShowHint : MonoBehaviour
{
    public List<GameObject> HiddenObjects = new List<GameObject>();
    private int RandomNumber = 0;
    public GameObject ObjectHintGlow;
    public AudioSource ShowHintSoundGliss;
    public AudioSource ShowHintSoundChimes;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        for (int i = HiddenObjects.Count - 1; i >= 0; i--){
            if (HiddenObjects[i] == null){
                HiddenObjects.RemoveAt(i);
            }

            if (HiddenObjects.Count == 0){
                print("All Objects Found");
            }
        }

        RandomNumber = Random.Range(0,HiddenObjects.Count);
        if(HintMeter.HintUsed == true){
            Instantiate(ObjectHintGlow, HiddenObjects[RandomNumber].transform.position, Quaternion.identity);
            ShowHintSoundGliss.Play();
            ShowHintSoundChimes.Play();
            HintMeter.HintUsed = false;
        }
    }
}
