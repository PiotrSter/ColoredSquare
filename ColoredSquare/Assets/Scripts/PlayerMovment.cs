using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed, jumpForce, movementSpeedOnAir;
    public bool isGround, canMoveLeft, canMoveRight, changeColor, isPlayerSpeedUp, drawColor;
    GameObject feet;
    public Vector3 playerPosition;
    GameManager gm;
    public Renderer renderer;
    public int time, randomMaterial;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        feet = GameObject.Find("Feet");
        canMoveLeft = true;
        canMoveRight = true;
        playerPosition = this.gameObject.transform.position;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        movementSpeed = 5f;
        jumpForce = 10f;
        renderer = this.gameObject.GetComponent<Renderer>();
        changeColor = false;
        drawColor = false;
        movementSpeedOnAir = movementSpeed;
        isPlayerSpeedUp = false;
    }


    void Update()
    {
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



        /*feet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.45f, this.transform.position.z);
        feet.transform.rotation = Quaternion.identity;
        w razie gdybym jednak chcia³ ¿eby kwadrat móg³ siekrêciæ wzgledem osi z*/

        if (drawColor)
            DrawMaterial();

        if (changeColor)
            ChangeColor();
    }

    void DrawMaterial()
    {
        randomMaterial = Random.Range(0, 3);
        drawColor = false;
    }

    void ChangeColor()
    {
        renderer.material = gm.materialsTab[randomMaterial];
        changeColor = false;
    }

    void SpeedUp()
    {
        isPlayerSpeedUp = true;
        if (movementSpeed < 10f)
            movementSpeed += 0.1f;  
    }

}
