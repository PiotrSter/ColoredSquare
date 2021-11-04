using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    public Renderer playerRenderer, floorRenderer;
    public WallBehavior leftWall, rightWall;
    void Awake()
    {
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        playerRenderer = GameObject.Find("Player").GetComponent<Renderer>();
        floorRenderer = gameObject.GetComponentInParent<Renderer>();
        leftWall = GameObject.Find("LeftWall").GetComponent<WallBehavior>();
        rightWall = GameObject.Find("RightWall").GetComponent<WallBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Feet")
        {
            if ((playerRenderer.material.name == floorRenderer.material.name) || (playerRenderer.material.name == "White (Instance)") || (floorRenderer.material.name == "White (Instance)"))
            {
                boxCollider2D.isTrigger = false;
                player.isGround = true;
                leftWall.canBounce = true;
                rightWall.canBounce = true;
                /*player.canMoveLeft = true;
                player.canMoveRight = true;*/
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Feet")
        {
            boxCollider2D.isTrigger = true;
            player.isGround = false;
        }
    }
}
