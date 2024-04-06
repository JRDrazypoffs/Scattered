using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogAnimatorNarration : MonoBehaviour
{
    public GameObject WhatsWrongBtn;
    public GameObject NarrativePanel;

    public TMP_Text NarrativeText;

    private DialogueVertexAnimator dialogueVertexAnimator;
    public int DelayDialogTriggerBtnBySecs;

    private string Sentence;

    // Start is called before the first frame update
    void Start()
    {
        DisplayNarration();
        DelayWhatsWrongBtn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayNarration(){
        if(NarrativePanel.activeSelf==true){
            Sentence = NarrativeText.text;
            dialogueVertexAnimator = new DialogueVertexAnimator(NarrativeText);
            PlayDialogue(Sentence);
        }
    }
    public void DelayWhatsWrongBtn() {
        StartCoroutine(TemporarilyDeactivate(DelayDialogTriggerBtnBySecs));
    }

    private IEnumerator TemporarilyDeactivate(float duration) {
        WhatsWrongBtn.SetActive(false);
        yield return new WaitForSeconds(duration);
        WhatsWrongBtn.SetActive(true);
    }

    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, null));
    }
}
