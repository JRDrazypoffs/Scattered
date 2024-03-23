using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckMBCylinder : MonoBehaviour
{
    public GameObject EmptyMusicBox;
    public GameObject MusicBox;
    public GameObject MusicBoxCylinder;
    public GameObject TooltipPanel;
    public GameObject ButtonsPanel;

    public AudioSource SparkleSound;
    public Transform Sparkle;
    public Transform MusicBoxPos;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        bool IsInside = EmptyMusicBox.GetComponent<PolygonCollider2D>().IsTouching(MusicBoxCylinder.GetComponent<PolygonCollider2D>());

        if(IsInside){
            // Destroy(EmptyMusicBox);
            // Destroy(MusicBoxCylinder);
            EmptyMusicBox.SetActive(false);
            MusicBoxCylinder.SetActive(false);
            MusicBox.SetActive(true);
            Instantiate(Sparkle, MusicBoxPos.position, Sparkle.rotation);
            SparkleSound.Play();
            TooltipPanel.SetActive(false);
            ButtonsPanel.SetActive(true);
        }   
    }

    public void GotoEndSequence(){
        SceneManager.LoadSceneAsync("Ending Sequence");
    }
    
}
