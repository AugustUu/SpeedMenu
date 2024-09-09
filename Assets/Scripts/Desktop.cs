using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.EventSystems;

public class Desktop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public List<DesktopIcon> selected_icons;
    public List<DesktopIcon> icons;
    public Rect select_area;
    public Vector2 select_pos1;
    public Vector2 select_pos2;
    public RectTransform select_rect;
    private bool clicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            UpdateSelectRect();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClearSelect();
        Debug.Log("desktop clicked");
        select_pos1 = Input.mousePosition;
        select_rect.gameObject.SetActive(true);
        UpdateSelectRect();
        clicked = true;
    }

    public void ClearSelect()
    {
        if (!(Input.GetKey("right ctrl") || Input.GetKey("left ctrl") || Input.GetKey("left shift") || Input.GetKey("right shift"))) // bad code sob
        {
            foreach(DesktopIcon icon in selected_icons)
            {
                icon.Highlight(false);
            }
            selected_icons.Clear();
            Debug.Log("cleared selection");
        }
    }

    public void Select(DesktopIcon icon) // no deselect functionality cause never have to do that individually (dumb)
    {
        icon.Highlight(true);
        selected_icons.Add(icon);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        clicked = false;
        select_rect.gameObject.SetActive(false);
    }

    public void UpdateSelectRect()
    {
        select_pos2 = Input.mousePosition;
        select_area = new Rect(Mathf.Min(select_pos1.x, select_pos2.x), Mathf.Min(select_pos1.y, select_pos2.y),
            Mathf.Abs(select_pos2.x - select_pos1.x), Mathf.Abs(select_pos2.y - select_pos1.y));
        select_rect.position = select_area.center;
        select_rect.sizeDelta = new Vector2(select_area.width, select_area.height);

        foreach(DesktopIcon icon in icons)
        {
            if(!selected_icons.Contains(icon))
            {
                RectTransform icon_rt = icon.GetComponent<RectTransform>();
                if (select_area.Overlaps(GetWorldRect(icon_rt)))
                {
                    Select(icon);
                }
            }
        }
    }
    
    public Rect GetWorldRect(RectTransform rectTransform) // stolen code idfk what this does
    {
        var localRect = rectTransform.rect;

        return new Rect
        {
            min = rectTransform.TransformPoint(localRect.min),
            max = rectTransform.TransformPoint(localRect.max)
        };
    }
}
