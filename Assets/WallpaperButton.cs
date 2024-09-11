using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WallpaperButton : MonoBehaviour
{

    public Sprite wallpaper;

    private Image desktop_image;

    private UseableButton button = null;


    void Start()
    {
        button = this.GetComponent<UseableButton>();
        desktop_image = GameObject.Find("Desktop").GetComponent<Image>();
        button.OnPointerClickEvent.AddListener(OnPointerClick);
    }

    void OnPointerClick(PointerEventData eventData)
    {
        desktop_image.sprite = wallpaper;    
        Debug.Log("new wallpaper");
    }
}
