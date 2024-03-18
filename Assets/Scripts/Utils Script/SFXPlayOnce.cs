using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SFXPlayOnce : MonoBehaviour
{
    // this script is intended to play sfx once but seems like it didnt behave as intended.
    
    [Header("Audio Source")]
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]

    public AudioClip PopSFX;


    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
