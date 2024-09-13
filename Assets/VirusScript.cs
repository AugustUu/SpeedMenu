using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour
{
    Vector3 targetPosition;
    
    Desktop desktop;

    public GameObject lazer;

    void Start()
    {
        targetPosition = this.transform.position;
        desktop = transform.parent.Find("Desktop").GetComponent<Desktop>();
        
    }

    Vector3 random_pos()
    {
        Vector3 test = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0);

        foreach (var desktopIcon in desktop.icons)
        {
            if (Vector3.Distance(desktopIcon.transform.position, test) < 400f)
            {
                Debug.Log( "bad position " + Vector3.Distance(desktopIcon.transform.position, test));
                return random_pos();
            }
        }
        return test;
    }
    
    private float delay = 0;
    void Update()
    {
        if (targetPosition == this.transform.position)
        {
            
            if (Time.time > delay + 4f)
            {
                targetPosition = random_pos();

            }
            else
            {
                if (Time.time > delay + 1f){
                    DesktopIcon target = desktop.icons[Random.Range(0, desktop.icons.Count)];

                    GameObject lazerClone = Instantiate(lazer, transform.parent.transform);
                    
                    lazerClone.transform.rotation = Quaternion.Euler(0, 0,Mathf.Rad2Deg * Mathf.Atan2(target.transform.position.y - transform.position.y,target.transform.position.x - transform.position.x));
                    
                    lazerClone.transform.position = transform.position;
                    delay = Time.time;
                }
            }
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * 300f);
            delay = Time.time;
        }

    }
}
