using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.EventSystems;

public class Desktop : MonoBehaviour, IPointerClickHandler
{
    public List<DesktopIcon> selected_icons;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < selected_icons.Count; i++)
        {
            selected_icons[i].Highlight(false);
        }
        selected_icons.Clear();
    }
}
