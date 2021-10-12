using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor;
    public Transform player;
    public int howManyFloor = 0, i = 0;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        SpawnFloor();
        SpawnFloor();
        SpawnFloor();
    }

    void Update()
    {
        
    }

    void SpawnFloor()
    {
        float x = Random.Range(-8f, 8f), y = Random.Range(player.transform.position.y + 1, player.transform.position.y + 5), sizeX = Random.Range(1f, 8.5f);
        floor.transform.localScale = new Vector3(sizeX, floor.transform.localScale.y, floor.transform.localScale.z);
        Instantiate(floor, new Vector3(x, y, 0), Quaternion.identity);
    }
}
