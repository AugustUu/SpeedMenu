using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WallpaperButton : MonoBehaviour
{

    public Sprite wallpaper;

    private GameObject WallpaperPreview;

    private UseableButton button = null;


    void Start()
    {
        button = this.GetComponent<UseableButton>();
        WallpaperPreview = this.transform.parent.transform.parent.transform.parent.transform.parent.Find("WallpaperPreview").gameObject;
        button.OnPointerClickEvent.AddListener(OnPointerClick);
    }

    void OnPointerClick(PointerEventData eventData)
    {
        WallpaperPreview.GetComponent<Image>().sprite = wallpaper;    
        Debug.Log("new wallpaper");
    }
}
