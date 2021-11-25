using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public PlayerMovment player;
    public bool canBounce;
    public string gameObjectName;
    public float reflectionPowerHorizontal, reflectionPowerVertical;
    public Transform wallTransform, leftWall, rightWall;
    public GameManager gm;
    void Awake()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        gameObjectName = this.gameObject.name;
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        wallTransform = this.gameObject.transform;
        leftWall = GameObject.Find("LeftWall").GetComponent<Transform>();
        rightWall = GameObject.Find("RightWall").GetComponent<Transform>();
        reflectionPowerHorizontal = 8f;
        reflectionPowerVertical = 8f;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        canBounce = true;
    }

    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.player.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            //player.canMove = false;
            //player.movementSpeed = 4.5f;
            if (gameObjectName == "LeftWall")
            {
                player.canMoveLeft = false;
                player.canMoveRight = true;
                if (canBounce)
                {
                    rb.velocity = new Vector2(reflectionPowerHorizontal, reflectionPowerVertical);
                    canBounce = false;
                }
            }
            else if (gameObjectName == "RightWall")
            {
                player.canMoveRight = false;
                player.canMoveLeft = true;
                if (canBounce)
                {
                    rb.velocity = new Vector2(-reflectionPowerHorizontal, reflectionPowerVertical);
                    canBounce = false;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            if (gameObjectName == "LeftWall")
                player.canMoveLeft = true;
            else if (gameObjectName == "RightWall")
                player.canMoveRight = true;
        }
    }
}
