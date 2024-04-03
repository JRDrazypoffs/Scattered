using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogAnimator : MonoBehaviour
{
    // [SerializeField] TMP_Text[] DialoguesText;
    public GameObject[] Dialogues;
    private static string Sentence;
    private static int index;
    
    // Start is called before the first frame update
    void Start()
    {
        Sentence = Dialogues[index].GetComponent<TMP_Text>().text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(Sentence, index));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<Dialogues.Length; i++){
            if(Dialogues[i].activeSelf==true){
                index = i;
            }
        }
        
    }

    IEnumerator TypeSentence (String sentence, int index){
        Dialogues[index].GetComponent<TMP_Text>().text = "";
        foreach(char letter in sentence.ToCharArray()){
            Dialogues[index].GetComponent<TMP_Text>().text += letter;
            yield return null;
        }
    }
}
