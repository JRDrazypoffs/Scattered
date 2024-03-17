using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start(){
    }

    // // Update is called once per frame
    // void Update(){
    // }

    public void ToMap(){
        SceneManager.LoadSceneAsync("Map");
    }

}
