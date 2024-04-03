using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogAnimatorTooltips : MonoBehaviour
{
    public GameObject[] Dialogues;
    private static string Sentence;
    // private string[] SentenceBuffer;
    private static int index;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateTooltipsText(){
        for(int i = 0; i < Dialogues.Length; i++){
            if(Dialogues[i].activeSelf==true){
                index = i;
            }
        }
        Sentence = Dialogues[index].GetComponent<TMP_Text>().text;
        StartCoroutine(TypeSentence(Sentence, index));
    }

    public void StopAnimation(){
        // this function will stop the animationof other elements
        StopAllCoroutines();
    }

    IEnumerator TypeSentence (String sentence, int index){
        Dialogues[index].GetComponent<TMP_Text>().text = "";
        foreach(char letter in sentence.ToCharArray()){
            Dialogues[index].GetComponent<TMP_Text>().text += letter;
            yield return null;
        }
    }
}
