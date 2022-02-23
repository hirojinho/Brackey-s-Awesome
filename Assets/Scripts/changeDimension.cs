using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class changeDimension : MonoBehaviour
{
    public GameObject[] tms, enemies, btdr, portals;
    public bool dream = false;
    private GameObject cam;
    public GameObject activeOnA, activeOnB;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        tms = GameObject.FindGameObjectsWithTag("Tilemap");
        cam = GameObject.FindWithTag("MainCamera");
        btdr = GameObject.FindGameObjectsWithTag("BtDr");
        portals = GameObject.FindGameObjectsWithTag("Teleport");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            ChangeSprite();
            //cam.transform.position = Vector3.Scale(cam.transform.position, new Vector3(1, 1, -1));
        }
    }

    void ChangeSprite()
    {
        if(!dream)
        {
            //Happens when you go to B
            foreach(GameObject tileMap in tms)
            {
                tileMap.GetComponent<Tilemap>().SwapTile(tileMap.GetComponent<spriteOptions>().sprites[0],
                    tileMap.GetComponent<spriteOptions>().sprites[1]);
            }
            activeOnA.SetActive(false);
            activeOnB.SetActive(true);
            foreach(GameObject en in enemies)
            {
                en.SetActive(false);
            }
            DimTeleport(false);
            ButtonsAndDoorsActive(true);

            dream = true;
        }

        else
        {
            //Happens when you go to A
            foreach(GameObject tileMap in tms)
            {
                tileMap.GetComponent<Tilemap>().SwapTile(tileMap.GetComponent<spriteOptions>().sprites[1],
                    tileMap.GetComponent<spriteOptions>().sprites[0]);
            }
            activeOnA.SetActive(true);
            activeOnB.SetActive(false);
            foreach(GameObject en in enemies)
            {
                en.SetActive(true);
            }
            DimTeleport(true);
            ButtonsAndDoorsActive(false);
            
            dream = false;
        }
    }

    void ButtonsAndDoorsActive(bool active)
    {
        //Button active or not
        foreach(GameObject btdrs in btdr)
        {
            btdrs.transform.GetChild(0).GetComponent<Collider2D>().enabled = active;
            btdrs.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = active;
            if(active == false)
            {
                btdrs.transform.GetChild(0).GetComponent<OpenDoor>().timesPressed = 0;
            }
            if(btdrs.transform.GetChild(0).GetComponent<OpenDoor>().triggered == true)
            {
                btdrs.transform.GetChild(1).GetComponent<Collider2D>().enabled = !active;
                btdrs.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = !active;
                if(active == true)
                {
                    btdrs.transform.GetChild(0).GetComponent<OpenDoor>().triggered = false;
                }
            }
        }
    }

    void DimTeleport(bool active)
    {
        foreach(GameObject portal in portals)
        {
            portal.GetComponent<Collider2D>().enabled = active;
            portal.GetComponent<SpriteRenderer>().enabled = active;
        }
    }
}
