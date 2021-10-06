using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 5f, jumpForce = 3f;
    public bool isGround;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            isGround = false;
    }
}
