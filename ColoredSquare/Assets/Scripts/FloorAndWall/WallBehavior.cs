using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public PlayerMovment player;
    public bool isTimerOn, canBounce;
    public string gameObjectName;
    public float reflectionPowerHorizontal, reflectionPowerVertical;
    public int time;
    public Transform wallTransform;
    public GameManager gm;
    void Awake()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        gameObjectName = this.gameObject.name;
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        wallTransform = this.gameObject.transform;
        reflectionPowerHorizontal = 8f;
        reflectionPowerVertical = 8f;
        time = 180;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        canBounce = true;
    }

    void Update()
    {
        /*if (isTimerOn)
        {
            if (time == 0)
            {
                player.canMove = true;
                isTimerOn = false;
                time = 180;
            }
            else if (time > 0)
                time--;       
        }*/

        if (gm.floorNumber % 31 == 0)
            wallTransform.localScale = new Vector3(wallTransform.localScale.x, wallTransform.localScale.y + 50, wallTransform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            //player.canMove = false;
            //player.movementSpeed = 4.5f;
            isTimerOn = true;
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
