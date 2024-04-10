using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SplashScreenUtils : MonoBehaviour
{
    public TMP_Text JRDrazypoffs;
    public GameObject PresentsText;

    public GameObject Logo;
    public GameObject BlockerPanel;

    public AudioSource EndType;

    private DialogueVertexAnimator dialogueVertexAnimator;

    // Start is called before the first frame update
    void Start()
    {
        dialogueVertexAnimator = new DialogueVertexAnimator(JRDrazypoffs);
        PlayDialogue("<anim:wave>"+JRDrazypoffs.text+"</anim>");
        PresentsText.SetActive(true);
        DelaySoundNSecs(0.5f);
        DelayBlocker100(3f);
        Invoke("GotoMainMenu",4f);
    }

    void Update(){
        
    }

    void GotoMainMenu(){
        SceneManager.LoadSceneAsync("Main Menu");
    }
    
    public void DelayBlocker100(float Secs) {
        StartCoroutine(TemporarilyActivateBlocker(Secs));
    }

    public void DelaySoundNSecs(float Secs) {
        StartCoroutine(TemporarilyDeactivateSound(Secs));
    }

    private IEnumerator TemporarilyDeactivateSound(float duration) {
        yield return new WaitForSeconds(duration);
        EndType.Play();
    }

    private IEnumerator TemporarilyActivateBlocker(float duration) {
        yield return new WaitForSeconds(duration);
        BlockerPanel.SetActive(true);
    }

    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, null));
    }
}
