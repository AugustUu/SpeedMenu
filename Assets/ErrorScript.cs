using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorScript : MonoBehaviour
{

    public List<Sprite> icons;
    public List<String> messages;

    void Start()
    {
        this.transform.Find("Message").GetComponent<TMP_Text>().text = messages[UnityEngine.Random.Range(0, messages.Count)];
        this.transform.Find("Icon").GetComponent<Image>().sprite = icons[UnityEngine.Random.Range(0, icons.Count)];
    }

    void Update()
    {
        
    }
}
