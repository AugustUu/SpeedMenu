using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{

    private float start_time;
    public Desktop desktop;


    void Start()
    {
        
        start_time = Time.time; 
    }

    
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * 250;
        if ( Time.time > start_time+5 )
        {
            Destroy(gameObject);
        }

        foreach (var icon in desktop.icons)
        {
            if (Vector3.Distance(icon.transform.position, transform.position) < 60f)
            {
                icon.GetComponent<DesktopIcon>().dammage(0.1f);
                Debug.Log(icon.name + " dead");
                Destroy(gameObject);
            }
            else
            {
               //Debug.Log(Vector3.Distance(icon.transform.position, transform.position));     
            }
        }
        
    }
}
