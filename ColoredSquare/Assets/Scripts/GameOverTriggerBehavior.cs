using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriggerBehavior : MonoBehaviour
{
    GameManager gm;
    Rigidbody2D rb;
    public float speed;
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        speed = 1.5f;
    }

    void Update()
    {
        if (gm.isGameStart)
            rb.velocity = transform.up * speed;
        if (gm.changeSpeed)
        {
            speed += 0.5f;
            gm.changeSpeed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            gm.isGameOver = true;
    }
}
