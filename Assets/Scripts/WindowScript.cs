using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WindowScript : MonoBehaviour
{
    private UseableButton CloseButton;
    private UseableButton MaxButton;
    private UseableButton TitleButton;

    private RectTransform WindowRectTransform;

    private bool IsFullScreen = false;

    public enum DragedElement
    {
        None,
        Window,
        Size,
    }

    public DragedElement element;


    void Start()
    {
        WindowRectTransform = this.GetComponent<RectTransform>();

        CloseButton = this.transform.Find("Close").gameObject.GetComponent<UseableButton>();
        MaxButton = this.transform.Find("Max").gameObject.GetComponent<UseableButton>();
        TitleButton = this.transform.Find("Title").gameObject.GetComponent<UseableButton>();

        CloseButton.OnPointerDownEvent.AddListener(Close);
        MaxButton.OnPointerDownEvent.AddListener(Max);
        TitleButton.OnDragEvent.AddListener(DragWindow);

        TitleButton.OnPointerDownEvent.AddListener(ClickWindow);
    }

    void Close(PointerEventData eventData)
    {
        Destroy(this.gameObject);
    }

    private Vector2 OgSize = Vector2.zero;
    private Vector3 OgPosition = Vector3.zero;
    void Max(PointerEventData eventData)
    {

        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetAsLastSibling();

        IsFullScreen = !IsFullScreen;

        if (IsFullScreen)
        {
            OgSize = WindowRectTransform.sizeDelta;
            OgPosition = this.transform.position;
            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 99);
            WindowRectTransform.sizeDelta = Vector2.one;
        }
        else
        {
            WindowRectTransform.sizeDelta = OgSize;
            this.transform.position = OgPosition;
        }


    }
    void DragWindow(PointerEventData eventData)
    {
        if(!IsFullScreen){
            this.transform.position = eventData.position + DragOffset;
        }
    }

    private Vector2 DragOffset = Vector2.zero;
    void ClickWindow(PointerEventData eventData){
        
        
        GameObject parent = eventData.pointerCurrentRaycast.gameObject.transform.parent.transform.parent.gameObject;
        
        parent.transform.SetAsLastSibling();
        
        DragOffset = new Vector2(parent.transform.position.x,parent.transform.position.y) - eventData.position;
        //Debug.Log(parent.name + " " +parent.transform.position + " " + eventData.position + " " + DragOffset);
        
    }



    void Update()
    {


    }
}
