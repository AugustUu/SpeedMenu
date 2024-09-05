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
    public Rect bounds;
    private Vector2 drag_offset = Vector2.zero;
    public bool highlighted;
    
    // Start is called before the first frame update
    void Start()
    {
        icon_image = GetComponentInChildren<Image>();
        icon_text = GetComponentInChildren<TextMeshProUGUI>();
        icon_text.text = app_name;
        desktop = GetComponentInParent<Desktop>();
        bounds.center = transform.position;
        bounds.size = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        desktop.ClearSelect();
        desktop.selected_icons.Add(this);
        Highlight(true);
        drag_offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
    }

    public void Highlight(bool on)
    {
        if (on)
        {
            icon_image.color = new Color(0.25f, 0.35f, 0.80f);
            icon_text.text = "<mark=#3958D460>" + app_name;
            highlighted = true;
        }
        else
        {
            icon_image.color = new Color(1f, 1f, 1f);
            icon_text.text = app_name;
            highlighted = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + drag_offset;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.realtimeSinceStartup - time_last_clicked <= 0.25f)
        {
            Debug.Log("bah");
        }
        time_last_clicked = Time.realtimeSinceStartup;
    }
}
