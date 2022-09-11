using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float startMoveSpeed = 5f;
    [HideInInspector]
    public float moveSpeed;
    public float moveSmooth = .3f;
    private Vector2 movement;
    Vector2 velocity; 

    public static Vector2 Position;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = startMoveSpeed;
    }    
    private void FixedUpdate()
    {
        Movement();
    }     
    void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Vector2 desiredVelocity = movement * moveSpeed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);
        Position = rb.position;
    }
    void Dash()
    {

    }
}
