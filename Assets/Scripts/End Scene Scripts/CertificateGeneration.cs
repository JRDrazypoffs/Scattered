using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CertificateGeneration : MonoBehaviour
{
    [SerializeField] TMP_Text successMessage;
    public GameObject certificatePanel;


    private string username;
    private string firstClearDate;

    // Start is called before the first frame update
    void Start(){
        int currentLevel=PlayerPrefs.GetInt("Reached Index");

        System.DateTime dt = System.DateTime.Now;
        dt = dt.Add(System.TimeSpan.FromSeconds(180));

        var offset = System.DateTimeOffset.Now.Offset;
        // string dateString = dt.ToString("dd-MM-yyyy") + offset.Hours.ToString("00") + offset.Minutes.ToString("00");
        string dateString = dt.ToString("dd.MM.yyyy");

        if(!PlayerPrefs.HasKey("Player Pref First Clear Date")){
            if(currentLevel>=10){
                PlayerPrefs.SetString("Player Pref First Clear Date",dateString);
            }
        }

        username = PlayerPrefs.GetString("Player Pref Username");
        firstClearDate = PlayerPrefs.GetString("Player Pref First Clear Date");
    }

    // Update is called once per frame
    void Update(){
        // <color=#60B2D7>
        successMessage.text = "This certificate is awarded to \n<size=200%><color=#60B2D7><b>"+username+"</b></color></size> \nfor completing <size=120%><color=#F0C75E><b>Scattered: <size=80%>In Search of Kitt</size></b></color></size> on "+firstClearDate+".";
    }
}
