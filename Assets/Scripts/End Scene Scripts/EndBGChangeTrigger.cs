using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBGChangeTrigger : MonoBehaviour
{
    public GameObject BGGlow;
    public GameObject BGEnd;

    // public AudioSource BGM;
    public int DelayGlowBGTriggerBySecs;
    public float DelayEndBGTriggerBySecs;
    

    // Start is called before the first frame update
    void Start()
    {
        DelayGlowBG();
        DelayEndBG();
    }

    public void DelayGlowBG() {
        StartCoroutine(TemporarilyDeactivateGlowBG(DelayGlowBGTriggerBySecs));
    }

    private IEnumerator TemporarilyDeactivateGlowBG(float duration) {
        BGGlow.SetActive(false);
        yield return new WaitForSeconds(duration);
        BGGlow.SetActive(true);
    }

    public void DelayEndBG() {
        StartCoroutine(TemporarilyDeactivateEndBG(DelayEndBGTriggerBySecs));
    }

    private IEnumerator TemporarilyDeactivateEndBG(float duration) {
        BGEnd.SetActive(false);
        yield return new WaitForSeconds(duration);
        BGEnd.SetActive(true);
    }
}
