using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSafeguard : MonoBehaviour
{
    public PlayerMovment player;
    public string gameObjectName;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        gameObjectName = this.gameObject.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Feet")
        {
            if (gameObjectName == "LeftSideSafeguard")
                player.canMoveRight = false;
            else if (gameObjectName == "RightSideSafeguard")
                player.canMoveLeft = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Feet")
        {
            if (gameObjectName == "LeftSideSafeguard")
                player.canMoveRight = true;
            else if (gameObjectName == "RightSideSafeguard")
                player.canMoveLeft = true;
        }
    }
}
