using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor, floorCreated, pastFloor;
    public Transform player;
    public GameManager gm;
    public int floorNumber;
    public float spawningPlatfoprmHeight;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        floorNumber = 1;
        spawningPlatfoprmHeight = -2f;
        SpawnFloor();
        SpawnFloor();
        SpawnFloor();
    }

    void Update()
    {
        if (gm.howManyFloorsCurentlly < 20)
            SpawnFloor();
    }

    void SpawnFloor()
    {
        float randomX, randomY, sizeX;
        if (floorNumber % 50 != 0)
        {
            randomX = Random.Range(-8f, 8f);
            sizeX = Random.Range(3f, 8.5f);
        }
        else
        {
            randomX = 0;
            sizeX = 19;
        }

        randomY = Random.Range(2f, 4f);        
        floor.transform.localScale = new Vector3(sizeX, floor.transform.localScale.y, floor.transform.localScale.z);
        floorCreated = Instantiate(floor, new Vector3(randomX, spawningPlatfoprmHeight, 0), Quaternion.identity);
        floorCreated.name = $"Floor{floorNumber}";
        floorNumber++;
        gm.howManyFloorsCurentlly++;
        spawningPlatfoprmHeight += randomY;
    }
}
