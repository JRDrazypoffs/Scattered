using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenu : MonoBehaviour
{
    public Animator HandAnimator;

    public void ToMap(){
        SceneManager.LoadSceneAsync("Map");
    }

}
