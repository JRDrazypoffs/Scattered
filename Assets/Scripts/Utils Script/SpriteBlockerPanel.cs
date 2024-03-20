using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBlockerPanel : MonoBehaviour
{
    public GameObject[] BlockerPanel;
    public GameObject ColliderSprite;

    // Update is called once per frame
    void Update(){
        // this method is not working for some reason
        // even when blocker[i] is active the sprites' collider is still enabled
        for(int i=0; i<BlockerPanel.Length; i++){
            if(BlockerPanel[i].activeSelf == true){
                ColliderSprite.GetComponent<Collider2D>().enabled = false;
            }else{
                ColliderSprite.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
