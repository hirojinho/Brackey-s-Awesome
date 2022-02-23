using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject player;
    public bool beingHandled = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 lookDir = player.GetComponent<Rigidbody2D>().position - rb.position;
        float angle = - Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
        if(lookDir.magnitude <= 7f && !beingHandled)
        {
            StartCoroutine(gameObject.GetComponent<EnemyShooting>().Shoot());
        }
    }
}
