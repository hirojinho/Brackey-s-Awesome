using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class changeDimension : MonoBehaviour
{
    public GameObject[] tms, enemies, btdr;
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
            foreach(GameObject btdrs in btdr)
            {
                btdrs.transform.GetChild(0).gameObject.SetActive(true);
                if(btdrs.transform.GetChild(0).GetComponent<OpenDoor>().triggered == true)
                {
                    btdrs.transform.GetChild(1).gameObject.SetActive(false);
                    btdrs.transform.GetChild(0).GetComponent<OpenDoor>().triggered = false;
                }
            }

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
            foreach(GameObject btdrs in btdr)
            {
                btdrs.transform.GetChild(0).gameObject.SetActive(false);
                btdrs.transform.GetChild(0).GetComponent<OpenDoor>().timesPressed = 0;
                if(btdrs.transform.GetChild(0).GetComponent<OpenDoor>().triggered == true)
                {
                    btdrs.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            
            dream = false;
        }
    }
}
