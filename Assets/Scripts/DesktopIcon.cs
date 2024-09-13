using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DesktopIcon : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IDragHandler
{
    public String app_name;
    
    private float time_last_clicked = 0;
    private Image icon_image;
    private TextMeshProUGUI icon_text;
    private Desktop desktop;
    public Vector2 drag_offset = Vector2.zero;
    [HideInInspector] public bool highlighted;
    public bool draggable = true;
    public GameObject app;
    public bool is_bullet = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!is_bullet)
        {
            icon_image = GetComponentInChildren<Image>();
            icon_text = GetComponentInChildren<TextMeshProUGUI>();
            icon_text.text = app_name;
            desktop = GetComponentInParent<Desktop>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!highlighted)
        {
            desktop.ClearSelect();
        }
        desktop.Select(this); // stupiddddd
        if(draggable)
        {
            foreach (DesktopIcon icon in desktop.selected_icons)
            {
                icon.drag_offset = new Vector2(icon.transform.position.x, icon.transform.position.y) - eventData.position; // move to desktop script (obviously why did i write this here)
            }
        }
    }

    public void Highlight(bool on)
    {
        if (on)
        {
            icon_image.color = new Color(0.25f, 0.35f, 0.80f);
            if (!is_bullet)
            {
                icon_text.text = "<mark=#3958D460>" + app_name;
            }
            highlighted = true;
        }
        else
        {
            icon_image.color = new Color(1f, 1f, 1f);
            if (!is_bullet)
            {
                icon_text.text = app_name;
            }
            highlighted = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(draggable)
        {
            foreach (DesktopIcon icon in desktop.selected_icons)
            {
                icon.transform.position = eventData.position + icon.drag_offset; // for sure bad way to do this idc
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.realtimeSinceStartup - time_last_clicked <= 0.25f)
        {
            if (!is_bullet)
            {
                Instantiate(app, GameObject.Find("Canvas").transform);
            }
        }
        time_last_clicked = Time.realtimeSinceStartup;
    }
}
