using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class TimeControl : MonoBehaviour
{
    [SerializeField] TMP_Text TimerText;
    [SerializeField] float RemainingTime;

    public AudioSource TimesUpSound;
    public AudioSource TickingSound;
    public AudioSource BGM;

    public GameObject TimesUpPanel;

    public Animator HandAnimator;

    public static int SoundTrigger = 0;


    // NOTE: Timer will not run if not set active


    // Start is called before the first frame update
    void Start(){
        SoundTrigger = 0;//reset counter on reload
    }

    // Update is called once per frame
    void Update(){
        // Count Down
        if(RemainingTime > 0){
            RemainingTime -= Time.deltaTime;
            HandAnimator.Play("HandTimerIdle");
        }else if(RemainingTime < 0){
            RemainingTime = 0;
            TimerText.color = Color.red;
            HandAnimator.Play("HandTimerOut");
            TickingSound.Stop();
            TimesUpSound.Play();
            BGM.Stop();
            TimesUpPanel.SetActive(true);//make popup appear
        }

        if(RemainingTime < 11){
            TimerText.color = Color.red;
                // use this silly method to stop the system from playing the sfx in infinite loop until triggered
                if(SoundTrigger == 10000){
                    SoundTrigger = 0;
                }else{
                    SoundTrigger++;
                }
        }

        if(SoundTrigger==1){
            TickingSound.Play();
        }

        int Minutes = Mathf.FloorToInt(RemainingTime / 60);
        int Seconds = Mathf.FloorToInt(RemainingTime % 60);
        // TimerText.text = RemainingTime.ToString();
        TimerText.text = string.Format("{0:00}:{1:00}",Minutes,Seconds);
    }

    public void RestartTheGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
