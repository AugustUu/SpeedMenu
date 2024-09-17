using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    TMP_Text text;
    int min = 5;
    int seconds = 0;

    public GameObject popup;
    public GameObject desktop;
    public GameObject winScreen;
    public GameObject Virus;

    void Start()
    {
        text = this.GetComponentInChildren<TMP_Text>();
        InvokeRepeating("tickClock",0f,1f);
    }

    void Win(){
       Desktop desktop_script = desktop.GetComponent<Desktop>();

        float avarge = 0;

       foreach(var icon in desktop_script.icons){
            avarge += icon.health;
       }
       avarge /= desktop_script.icons.Count;

       Debug.Log("score " + avarge);
       winScreen.SetActive(true);
       winScreen.GetComponentInChildren<TMP_Text>().text = "Score: " + Mathf.Round(avarge * 100) + "%";
       Destroy(Virus);
    }

    void tickClock(){
        if(min == 0 && seconds == 0){
            Win();
            CancelInvoke("tickClock");
        }

        if(seconds == 0){
            min -= 1;
            seconds = 59;
        }else{
            seconds -= 1;
        }

        if (seconds < 10)
        {
            text.text = "" + min + ":0" + seconds;
        }
        else
        {
            text.text = "" + min + ":" + seconds;
        }

        if(Random.Range(0,3 + min) == 0){
            Vector3 test = new Vector3(Random.Range(200, Screen.width -200), Random.Range(200, Screen.height -200), 0);
            GameObject new_popup = Instantiate(popup, desktop.transform);
            new_popup.transform.position = test;
        }
    }
    
}
