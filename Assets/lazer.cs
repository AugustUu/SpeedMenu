using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lazer : MonoBehaviour
{

    private float start_time;
    public Desktop desktop;
    public bool draggable;
    public RectTransform canvas;


    void Start()
    {
        start_time = Time.time; 
        canvas = transform.parent.GetComponent<RectTransform>();
    }

    
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * 250;
        if(!draggable){
            if(Mathf.Abs(transform.localPosition.x * 2) - 80 > canvas.sizeDelta.x || Mathf.Abs(transform.localPosition.y * 2) - 80 > canvas.sizeDelta.y){
                Destroy(gameObject);
            }
        }
        else
        {
            if(Mathf.Abs(transform.localPosition.x * 2) + 40 > canvas.sizeDelta.x){
                transform.rotation = Quaternion.Euler(0, 0, 180 - transform.rotation.eulerAngles.z);
            }
            else if(Mathf.Abs(transform.localPosition.y * 2) + 40 > canvas.sizeDelta.y){
                transform.rotation = Quaternion.Euler(0, 0, 0 - transform.rotation.eulerAngles.z);
            }
        }
        

        foreach (var icon in desktop.icons)
        {
            if (Vector3.Distance(icon.transform.position, transform.position) < 60f)
            {
                if(!icon.GetComponent<DesktopIcon>().is_trash){
                    icon.GetComponent<DesktopIcon>().dammage(0.15f);
                    // Debug.Log(icon.name + " dead");
                }
                if(draggable){
                    desktop.selected_icons.Remove(gameObject.GetComponent<DesktopIcon>());
                }
                if(!icon.GetComponent<DesktopIcon>().is_trash || draggable){
                    Destroy(gameObject);
                }
            }
            else
            {
               //Debug.Log(Vector3.Distance(icon.transform.position, transform.position));     
            }
        }
        
    }
}
