using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    void Awake()
    {
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Feet")
        {
            boxCollider2D.isTrigger = false;
            player.isGround = true;
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
