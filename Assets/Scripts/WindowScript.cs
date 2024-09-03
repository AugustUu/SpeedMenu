using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    public Button CloseButton;
    public Button MaxButton;
    public Button TitleButton;
    
    public bool IsFullScreen = false;
    
    void Start()
    {
        CloseButton = this.transform.Find("Close").gameObject.GetComponent<Button>();
        MaxButton = this.transform.Find("Max").gameObject.GetComponent<Button>();
        TitleButton = this.transform.Find("Title").gameObject.GetComponent<Button>();
        CloseButton.onClick.AddListener(Close);
        MaxButton.onClick.AddListener(Max);
        TitleButton.onClick.AddListener(Drag);
    }

    void Close()
    {
        Debug.Log("Close!");
    }

    void Max()
    {
        if (IsFullScreen){
            
        }else
        {
            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            this.GetComponent<RectTransform>().anchorMax = Vector2.one;
            this.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            //fix
    }
        IsFullScreen = !IsFullScreen;
        
        
    }

    void Drag()
    {
        Debug.Log("Drag!");
    }
    void Update()
    {
        //Debug.Log(TitleButton.interactable);
    }
}
