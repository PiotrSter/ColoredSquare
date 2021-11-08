using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    public Renderer playerRenderer, floorRenderer;
    public WallBehavior leftWall, rightWall;
    public FloorBehavior floor;
    void Awake()
    {
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        playerRenderer = GameObject.Find("Player").GetComponent<Renderer>();
        floorRenderer = gameObject.GetComponentInParent<Renderer>();
        leftWall = GameObject.Find("LeftWall").GetComponent<WallBehavior>();
        rightWall = GameObject.Find("RightWall").GetComponent<WallBehavior>();
        floor = gameObject.GetComponentInParent<FloorBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Feet")
        {
            if (playerRenderer.material.name == floorRenderer.material.name || playerRenderer.material.name == "White (Instance)" || floorRenderer.material.name == "White (Instance)")
            {
                boxCollider2D.isTrigger = false;
                player.isGround = true;
                leftWall.canBounce = true;
                rightWall.canBounce = true;
            }

            if (floor.number % 50 == 0)
            {
                player.changeColor = true;
                floor.gm.changeSpeed = true;
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
