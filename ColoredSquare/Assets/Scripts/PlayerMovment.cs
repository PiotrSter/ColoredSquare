using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed, jumpForce;
    public bool isGround, canMoveLeft, canMoveRight, changeColor;
    GameObject feet;
    public Vector3 playerPosition;
    GameManager gm;
    Renderer renderer;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        feet = GameObject.Find("Feet");
        canMoveLeft = true;
        canMoveRight = true;
        playerPosition = this.gameObject.transform.position;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        movementSpeed = 7f;
        jumpForce = 10f;
        renderer = this.gameObject.GetComponent<Renderer>();
        changeColor = false;
    }

    
    void Update()
    {
        if (isGround)
            movementSpeed = 7f;

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            gm.isGameStart = true;
        }

        if (Input.GetKey(KeyCode.A) && canMoveLeft)
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.D) && canMoveRight)
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

        /*feet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.45f, this.transform.position.z);
        feet.transform.rotation = Quaternion.identity;
        w razie gdybym jednak chcia³ ¿eby kwadrat móg³ siekrêciæ wzgledem osi z*/

        if (changeColor)
            DrawMaterial();
    }

    void DrawMaterial()
    {
        int randomMaterial = Random.Range(0, 3);
        renderer.material = gm.materialsTab[randomMaterial];
        changeColor = false;
    }
}
