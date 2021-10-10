using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public PlayerMovment player;
    public bool isCollison, isTimerOn;
    public string gameObjectName;
    public float reflectionPowerHorizontal = 10f, reflectionPowerVertical = 2f;
    public int time = 60;
    void Awake()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        gameObjectName = this.gameObject.name;
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
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
                time = 60;
            }
            else if (time > 0)
                time--;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            isCollison = true;
            player.canMove = false;
            isTimerOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
            isCollison = false;
    }
}
