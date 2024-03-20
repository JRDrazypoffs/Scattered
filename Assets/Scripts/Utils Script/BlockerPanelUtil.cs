using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerPanelUtil : MonoBehaviour
{
    // public List<GameObject> ColliderSprites = new List<GameObject>();//take in the sprites as list as array will throw error is destroyed
    public GameObject[] ColliderSprites;
    public GameObject BlockerPanel;

    void Update()
    {
        // attach this function to the blocker panels to prvent sprites from being selectable behind the UI panel
        // this function will break if the collider sprite is destroyed
        // use it when the collider sprite is not going to be destroyed

        // this function is will not go into the else statement for some reason

        if(BlockerPanel.activeSelf == true){
            for (int i = 0; i<ColliderSprites.Length; i++){
                ColliderSprites[i].GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    public void OnBlockerClose(){
        for (int i = 0; i<ColliderSprites.Length; i++){
            ColliderSprites[i].GetComponent<Collider2D>().enabled = true;
        }
    }
}
