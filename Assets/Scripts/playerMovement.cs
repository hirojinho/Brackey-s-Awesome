using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator animator;
    private Vector2 moveDirection;
    private GameObject cam;
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if(moveX > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            //cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(moveX < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            //cam.transform.rotation *= Quaternion.Euler(0, 180, 0);
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        animator.SetFloat("Speed", moveDirection.magnitude);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * moveDirection.x, moveSpeed * moveDirection.y);
    }
}
