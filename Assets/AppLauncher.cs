using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppLauncher : MonoBehaviour
{
    
    public GameObject app;
    
    private UseableButton button = null;

    void Start()
    {
        button = this.GetComponent<UseableButton>();
        button.OnPointerClickEvent.AddListener(OnPointerClick);
    }

    void OnPointerClick(PointerEventData eventData)
    {
        Object.Instantiate(app, GameObject.Find("Canvas").transform);
    }
 
}
