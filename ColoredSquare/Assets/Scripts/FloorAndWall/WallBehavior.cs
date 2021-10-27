using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public PlayerMovment player;
    public bool isCollison, isTimerOn;
    public string gameObjectName;
    public float reflectionPowerHorizontal, reflectionPowerVertical;
    public int time;
    public Transform wallTransform;
    void Awake()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        gameObjectName = this.gameObject.name;
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        wallTransform = this.gameObject.transform;
        reflectionPowerHorizontal = 8f;
        reflectionPowerVertical = 8f;
        time = 180;
    }

    void Update()
    {
        if (isCollison)
            if (gameObjectName == "LeftWall")
                rb.velocity = new Vector2(reflectionPowerHorizontal, reflectionPowerVertical);
            else if (gameObjectName == "RightWall")
                rb.velocity = new Vector2(-reflectionPowerHorizontal, reflectionPowerVertical);
        if (isTimerOn)
        {
            if (time == 0)
            {
                player.canMove = true;
                isTimerOn = false;
                time = 180;
            }
            else if (time > 0)
                time--;       
        }

        wallTransform.localScale = new Vector3(wallTransform.localScale.x, wallTransform.localScale.y + 1, wallTransform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            isCollison = true;
            player.canMove = false;
            player.movementSpeed = 4.5f;
            isTimerOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
            isCollison = false;
    }
}
