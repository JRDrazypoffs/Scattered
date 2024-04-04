using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.PlasticSCM.Editor.WebApi;

public class DialogueAnimatorInit : MonoBehaviour
{
    public GameObject ContinueBtn;
    public GameObject EnterHOGsceneBtn;
    public GameObject HelpToddBtn;
    public GameObject ToddSprite;
    public GameObject CharacterSprite;
    public TMP_Text CharacterNameTextField;
    public TMP_Text DialogTextField;


    [SerializeField] string ToddName;
    [SerializeField] string CharacterName;
    [SerializeField] int[] NPCDialogIndex;

    [TextArea(3, 10)]// Makes the text area larger by min and mx number of lines
    [SerializeField] string[] DialogLines;

    private DialogueVertexAnimator dialogueVertexAnimator;
    private int index=0;
    private int CurrentNPCDialogueIndex=0;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        CurrentNPCDialogueIndex=0;
        // DisplayDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(index==1){
            ContinueBtn.SetActive(false);
            HelpToddBtn.SetActive(true);
        }else{
            ContinueBtn.SetActive(true);
            HelpToddBtn.SetActive(false);
        }
    
        // if(index==4||index==5||index==7||index==8){
        if(NPCDialogIndex.Any(n => n == index)){
            CharacterNameTextField.text = CharacterName;
            CharacterSprite.SetActive(true);
            ToddSprite.GetComponent<Animator>().Play("ToddDarken");
            CharacterSprite.GetComponent<Animator>().Play("CharacterDarkenReverse");
        }else{
            CharacterNameTextField.text = ToddName;
            CharacterSprite.GetComponent<Animator>().Play("CharacterDarken");
            ToddSprite.GetComponent<Animator>().Play("ToddDarkenReverse");
        }

        if(index==DialogLines.Length){
            EnterHOGsceneBtn.SetActive(true);
            ContinueBtn.SetActive(false);
        }

    }

    public void DisplayDialogue(){
        dialogueVertexAnimator = new DialogueVertexAnimator(DialogTextField);
        PlayDialogue(DialogLines[index]);
    }

    public void IncreaseDialogIndex(){//proceed to the next dialogue line
        DisplayDialogue();
        index++;
    }
    public void EnterArea(string AreaName){//attach this to the last continue button to enter HOG scene
        SceneManager.LoadScene(AreaName);
    }

    private Coroutine typeRoutine = null;
    void PlayDialogue(string message) {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, null));
    }
}
