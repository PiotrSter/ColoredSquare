using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
    }

    void Update()
    {
        
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
