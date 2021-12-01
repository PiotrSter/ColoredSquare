using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed, jumpForce, movementSpeedOnAir;
    public bool isGround, canMoveLeft, canMoveRight, changeColor, isPlayerSpeedUp;
    public Vector3 playerPosition;
    GameManager gm;
    public Renderer renderer;
    public int time, randomMaterialNumber;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        canMoveLeft = true;
        canMoveRight = true;
        playerPosition = this.gameObject.transform.position;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        movementSpeed = 5f;
        jumpForce = 10f;
        renderer = this.gameObject.GetComponent<Renderer>();
        changeColor = false;
        movementSpeedOnAir = movementSpeed;
        isPlayerSpeedUp = false;
    }

    void Update()
    {
        if (gm.isGameOver)
            this.gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            gm.isGameStart = true;
        }

        if (Input.GetKey(KeyCode.A) && canMoveLeft)
        {
            if (isGround)
            {
                rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
                SpeedUp();
            }
            else
            {
                movementSpeedOnAir = movementSpeed;
                rb.velocity = new Vector2(-movementSpeedOnAir, rb.velocity.y);
            }
        }

        if (Input.GetKey(KeyCode.D) && canMoveRight)
        {
            if (isGround)
            {
                rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
                SpeedUp();
            }
            else
            {
                movementSpeedOnAir = movementSpeed;
                rb.velocity = new Vector2(movementSpeedOnAir, rb.velocity.y);
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            isPlayerSpeedUp = false;

        if (!isPlayerSpeedUp)
        {
            if (movementSpeed > 5.1f && isGround)
                movementSpeed -= 0.1f;
        }

        if (changeColor)
            ChangeColor();
    }

    public void DrawMaterial()
    {
        randomMaterialNumber = Random.Range(1, 3);
    }

    void ChangeColor()
    {
        renderer.material = gm.materialsTab[randomMaterialNumber];
        changeColor = false;
    }

    void SpeedUp()
    {
        isPlayerSpeedUp = true;
        if (movementSpeed < 10f)
            movementSpeed += 0.1f;  
    }

}
