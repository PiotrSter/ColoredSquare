using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    public FloorSpawner floorSpawner;
    public GameManager gm;
    private bool isColid;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        floorSpawner = GameObject.Find("GameManager").GetComponent<FloorSpawner>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        isColid = true;
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

        if (collision.tag == "Floor")
        {
            if (isColid)
            {
                Debug.Log($"{this.name}: {this.transform.position} {collision.name}: {collision.transform.position}");
                collision.transform.position = new Vector3(collision.transform.position.x, this.transform.position.y + 3f, collision.transform.position.z);
                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

                isColid = false;
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
