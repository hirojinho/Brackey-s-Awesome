using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletHit : MonoBehaviour
{
    private GameObject player, startPoint;
    private GameObject[] buttons; 
    public GameObject hole;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hole = GameObject.FindWithTag("Hole");
        buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach(GameObject button in buttons)
        {
            Physics2D.IgnoreCollision(button.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        Physics2D.IgnoreCollision(hole.GetComponent<TilemapCollider2D>(), GetComponent<Collider2D>());
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            startPoint = GameObject.FindWithTag("Starter");
            player.transform.position = startPoint.transform.position;
        }

        if(collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
