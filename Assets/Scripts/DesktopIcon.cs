using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class DesktopIcon : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IDragHandler, IPointerUpHandler
{
    public String app_name;
    
    private float time_last_clicked = 0;
    private Image icon_image;
    private GameObject icon_ghost;
    private TextMeshProUGUI icon_text;
    private Desktop desktop;
    public Vector2 drag_offset = Vector2.zero;
    [HideInInspector] public bool highlighted;
    public bool draggable = true;
    public bool dragging = false;
    public GameObject app;
    public bool is_bullet = false;
    public bool is_trash = false;
    
    public float health = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!is_bullet)
        {
            icon_image = transform.GetChild(1).GetComponent<Image>();
            icon_ghost = transform.GetChild(3).GameObject();
            icon_ghost.GetComponent<Image>().sprite = icon_image.sprite;
            icon_text = GetComponentInChildren<TextMeshProUGUI>();
            icon_text.text = app_name;
            desktop = GetComponentInParent<Desktop>();
        }
        else
        {
            icon_image = GetComponent<Image>();
            icon_ghost = transform.GetChild(0).gameObject;
            desktop = transform.parent.GetChild(0).GetComponent<Desktop>();
        }
    }

    public void dammage(float damage)
    {
        health -= damage;
        this.GetComponentInChildren<Slider>().value = health;
        
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
                if (icon.is_bullet)
                {
                    icon.drag_offset = new Vector2(icon.transform.position.x, icon.transform.position.y ) - eventData.position; 
                }
                else
                {
                    icon.drag_offset = new Vector2(icon.transform.position.x, icon.transform.position.y + 32.5f) - eventData.position; // move to desktop script (obviously why did i write this here)
                }
               
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
        UpdateGhosts(eventData);
    }

    public void UpdateGhosts(PointerEventData eventData){
        foreach (DesktopIcon icon in desktop.selected_icons)
        {
            if(icon.draggable)
            {
                icon.icon_ghost.SetActive(true);
                icon.icon_ghost.transform.position = eventData.position + icon.drag_offset; // for sure bad way to do this idc
                icon.dragging = true;
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

    public void OnPointerUp(PointerEventData eventData){
        foreach (DesktopIcon icon in desktop.selected_icons)
        {
            if(icon.draggable){
                if (is_bullet)
                {
                    icon.transform.position = eventData.position + new Vector2(icon.drag_offset.x, icon.drag_offset.y);
                }
                else
                {
                    icon.transform.position = eventData.position + new Vector2(icon.drag_offset.x, icon.drag_offset.y - 32.5f);
                }
                
                icon.icon_ghost.SetActive(false);
                icon.dragging = false;
            }
        }
    }
}
