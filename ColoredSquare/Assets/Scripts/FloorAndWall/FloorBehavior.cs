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
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Feet")
        {
            boxCollider2D.isTrigger = false;
            player.isGround = true;
        }

        if (collision.name == "GameOverTrigger")
            Destroy(this.gameObject);

        if (collision.name == "Floor(Clone)")
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z); // to nie dzia³a, bo trigger wy³apuje inny trigger a nie collidera

        /*if (collision.name == "LeftWall")
            this.transform.position = new Vector3(this.transform.position.x + ) gdybym chcia³ jednak przesuwaæ platformy któe spawnuja siê w œcianie i wystaja po za kamere*/
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
