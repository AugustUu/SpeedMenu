using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WallpaperButton : MonoBehaviour
{

    public Sprite wallpaper;

    private GameObject WallpaperPreview;

    private UseableButton button = null;
    private Image desktop;

    void Start()
    {
        button = this.GetComponent<UseableButton>();
        WallpaperPreview = this.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.Find("WallpaperPreview").Find("wallpaper").gameObject;
        button.OnPointerClickEvent.AddListener(OnPointerClick);
        button.OnPointerEnterEvent.AddListener(OnPointerEnter);
        button.OnPointerExitEvent.AddListener(OnPointerExit);
        desktop = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.Find("Desktop").GetComponent<Image>();
    }

    void OnPointerEnter(PointerEventData eventData){
        WallpaperPreview.GetComponent<Image>().sprite = wallpaper;
        this.GetComponent<TMP_Text>().color = Color.blue;
    }

    void OnPointerExit(PointerEventData eventData){
        this.GetComponent<TMP_Text>().color = Color.black;
    }
    void OnPointerClick(PointerEventData eventData)
    {
        desktop.sprite = wallpaper;    
        Debug.Log("new wallpaper");
    }
}
