using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UseableButton : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UnityEvent<PointerEventData> OnBeginDragEvent;
    public UnityEvent<PointerEventData> OnDragEvent;
    public UnityEvent<PointerEventData> OnEndDragEvent;
    public UnityEvent<PointerEventData> OnPointerClickEvent;
    public UnityEvent<PointerEventData> OnPointerDownEvent;
    public UnityEvent<PointerEventData> OnPointerEnterEvent;
    public UnityEvent<PointerEventData> OnPointerExitEvent;
    public UnityEvent<PointerEventData> OnPointerUpEvent;



    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Begin");
        OnBeginDragEvent.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        OnDragEvent.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Ended");
        OnEndDragEvent.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        OnPointerClickEvent.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
        OnPointerDownEvent.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse Enter");
        OnPointerEnterEvent.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse Exit");
        OnPointerExitEvent.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Mouse Up");
        OnPointerUpEvent.Invoke(eventData);
    }
}