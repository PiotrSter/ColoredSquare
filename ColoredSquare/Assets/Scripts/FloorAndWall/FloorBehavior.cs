using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    public GameManager gm;
    public int number;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GameOverTrigger")
        {
            Destroy(this.gameObject);
            gm.howManyFloorsCurentlly--;
        }

        /*if (collision.name == "Feet")
        {
            if (number % 50 == 0)
            {
                player.changeColor = true;
                gm.changeSpeed = true;
            }
        }*/
    }
}
