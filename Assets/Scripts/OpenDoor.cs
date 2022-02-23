using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool triggered = false, onTrigger = false;
    [HideInInspector]
    public int timesPressed = 0;
    public int timesToOpen;
    void Update()
    {
        if(Input.GetKeyDown("e") && onTrigger)
        {
            timesPressed++;
            if(timesPressed == timesToOpen)
            {
                timesPressed = 0;
                triggered = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        onTrigger = true;
    }

    void OnTriggerExit2D()
    {
        onTrigger = false;
    }
}
