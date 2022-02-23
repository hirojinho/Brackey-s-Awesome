using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletHit : MonoBehaviour
{
    private GameObject player, startPoint;
    public GameObject hole;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hole = GameObject.FindWithTag("Hole");
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
