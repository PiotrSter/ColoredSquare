using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public PlayerMovment player;
    public GameManager gm;
    public FloorSpawner floorSpawner;
    public int number, numberOfTrigger;
    public bool isVisited, go, canMove;
    public float speed;
    public Transform leftWallTransform, rightWallTransform;
    Rigidbody2D rb;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        isVisited = false;
        floorSpawner = GameObject.Find("GameManager").GetComponent<FloorSpawner>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        speed = 2f;
        canMove = false;
        leftWallTransform = GameObject.Find("LeftWall").GetComponent<Transform>();
        rightWallTransform = GameObject.Find("RightWall").GetComponent<Transform>();
    }

    void Update()
    {
        if (number > 100 && number % 50 != 0)
        {
            if (go)
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            else
                rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GameOverTrigger")
            Destroy(this.gameObject);

        if (collision.name == "LeftWall")
            go = false;

        if (collision.name == "RightWall")
            go = true;
    }
}
