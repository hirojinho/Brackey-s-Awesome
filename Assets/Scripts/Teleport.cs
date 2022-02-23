using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.GetChild(0).GetComponent<OpenDoor>().triggered == true)
        {
            teleportation(1);
            gameObject.transform.GetChild(0).GetComponent<OpenDoor>().triggered = false;
        }

        else if(gameObject.transform.GetChild(1).GetComponent<OpenDoor>().triggered == true)
        {
            teleportation(0);
            gameObject.transform.GetChild(1).GetComponent<OpenDoor>().triggered = false;
        }
    }

    void teleportation(int exit)
    {
        player.transform.position = gameObject.transform.GetChild(exit).gameObject.transform.position;
    }
}
