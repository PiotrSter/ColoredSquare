using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    public GameManager gm;
    private bool isColid;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        isColid = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
/*        if (collision.name == "Feet")
        {
            boxCollider2D.isTrigger = false;
            player.isGround = true;
        }*/

        if (collision.name == "GameOverTrigger")
        {
            Destroy(this.gameObject);
            gm.howManyFloorsCurentlly--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.name == "Feet")
        {
            boxCollider2D.isTrigger = true;
            player.isGround = false;
        }*/
    }
}
