using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 5f, jumpForce = 3f;
    public bool isGround;
    GameObject feet;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        feet = GameObject.Find("Feet");
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

        feet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.57f, this.transform.position.z);
        feet.transform.rotation = Quaternion.identity;
    }
}
