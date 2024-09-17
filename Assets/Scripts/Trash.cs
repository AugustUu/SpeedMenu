using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Desktop desktop;
    private bool trash_mode;

    public void OnPointerEnter(PointerEventData eventData)
    {
        trash_mode = true;
        Debug.Log("trash mode");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        trash_mode = false;
        Debug.Log("trash mode deactivated");
    }

    public void RunTrash()
    {
        if(trash_mode){
            foreach(DesktopIcon icon in desktop.selected_icons){
                if(!icon.is_trash){
                    Destroy(icon.gameObject);
                }
            }
        }
    }

    void Start()
    {
        desktop = GetComponentInParent<Desktop>();
    }



        void Update()
    {
        
    }
}
