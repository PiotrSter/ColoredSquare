using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager gm;
    public FloorSpawner floorSpawner;
    public PlayerMovment player;
    public bool isVisited;


    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        floorSpawner = gm.GetComponent<FloorSpawner>();
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GameOverTrigger")
            Destroy(this.gameObject);

        if (collision.name == "Player")
        {
            if (!isVisited)
            {
                isVisited = true;
                player.DrawMaterial();
                floorSpawner.Spawn();
            }
        }
    }
}
