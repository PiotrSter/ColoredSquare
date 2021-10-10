using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSafeguard : MonoBehaviour
{
    public PlayerMovment player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Feet")
            player.canMove = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Feet")
            player.canMove = true;
    }
}
