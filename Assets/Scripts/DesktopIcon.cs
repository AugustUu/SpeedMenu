using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DesktopIcon : MonoBehaviour, IPointerClickHandler
{
    public String app_name;
    
    private float time_last_clicked = 0;
    private Image icon_image;
    private TextMeshProUGUI icon_text;
    private Desktop desktop;
    
    // Start is called before the first frame update
    void Start()
    {
        icon_image = GetComponentInChildren<Image>();
        icon_text = GetComponentInChildren<TextMeshProUGUI>();
        icon_text.text = app_name;
        desktop = GetComponentInParent<Desktop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (Time.realtimeSinceStartup - time_last_clicked <= 0.25f)
        {
            Debug.Log("bah");
        }
        time_last_clicked = Time.realtimeSinceStartup;
        
        desktop.selected_icons.Add(this);
        Highlight(true);
    }

    public void Highlight(bool on)
    {
        if (on)
        {
            icon_image.color = new Color(0.25f, 0.35f, 0.80f);
            icon_text.text = "<mark=#3958D460>" + app_name;
        }
        else
        {
            icon_image.color = new Color(1f, 1f, 1f);
            icon_text.text = app_name;
        }
    }
    
}
