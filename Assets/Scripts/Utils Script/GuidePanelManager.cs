using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePanelManager : MonoBehaviour
{
    public GameObject[] Slides;

    public GameObject NextBtn;
    public GameObject BackBtn;
    public GameObject PlayBtn;

    private int SlideIndex;

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Slides.Length; i++){
            Slides[i].gameObject.SetActive(false);
            if(i==0){
                Slides[i].gameObject.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Slides.Length; i++){
            Slides[i].gameObject.SetActive(false);
            if(i==SlideIndex){
                Slides[i].gameObject.SetActive(true);
            }
        }

        if(SlideIndex==0){
            NextBtn.SetActive(true);
            BackBtn.SetActive(false);
            PlayBtn.SetActive(false);
        }else if(SlideIndex==Slides.Length-1){
            NextBtn.SetActive(false);
            BackBtn.SetActive(true);
            PlayBtn.SetActive(true);
        }else{
            NextBtn.SetActive(true);
            BackBtn.SetActive(true);
            PlayBtn.SetActive(false);
        }
    }

    public void NextSlide(){
        SlideIndex++;
    }
    public void PrevSlide(){
        SlideIndex--;
    }

}
