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
        for (int i = 0; i < selected_icons.Count; i++)
        {
            selected_icons[i].Highlight(false);
        }
        selected_icons.Clear();
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

        for (int i = 0; i < icons.Count; i++)
        {
            if (select_area.Overlaps(icons[i].bounds))
            {
                Debug.Log("buh");
            }
        }
    }
}
