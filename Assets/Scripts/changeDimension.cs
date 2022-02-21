using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class changeDimension : MonoBehaviour
{
    public GameObject[] tms;
    public bool dream = false;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        tms = GameObject.FindGameObjectsWithTag("Tilemap");
        cam = GameObject.FindWithTag("MainCamera");
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
            foreach(GameObject tileMap in tms)
            {
                tileMap.GetComponent<Tilemap>().SwapTile(tileMap.GetComponent<spriteOptions>().sprites[0],
                    tileMap.GetComponent<spriteOptions>().sprites[1]);
            }
            dream = true;
        }

        else
        {
            foreach(GameObject tileMap in tms)
            {
                tileMap.GetComponent<Tilemap>().SwapTile(tileMap.GetComponent<spriteOptions>().sprites[1],
                    tileMap.GetComponent<spriteOptions>().sprites[0]);
            }
            
            dream = false;
        }
    }
}
