using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimateIn : MonoBehaviour
{
    public GameObject[] cards;
    private int index = 0;
    public float animSpeed;

    // Start is called before the first frame update
    void Start(){
        AnimateCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimateCards(){
        foreach(GameObject card in cards){
            card.SetActive(false);
        }
        if(index <= cards.Length-1){
            StartCoroutine(GetCardAnimateIn());
        }
    }

    IEnumerator GetCardAnimateIn(){
        foreach(GameObject card in cards){
            card.SetActive(true);
            yield return new WaitForSeconds(animSpeed);
        }
        index++;
    }
}
