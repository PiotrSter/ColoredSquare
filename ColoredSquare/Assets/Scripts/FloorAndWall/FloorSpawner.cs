using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor, floorCreated, pastFloor;
    public Transform player;
    public GameManager gm;
    public float spawningPlatfoprmHeight;
    Renderer floorRenderer; 
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.floorNumber = 1;
        floorRenderer = floor.GetComponent<Renderer>();
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
        int randomMaterial = Random.Range(0, 3);

        if (gm.floorNumber % 50 != 0)
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
        floorCreated.name = $"Floor{gm.floorNumber}";
        floorRenderer.material = gm.materialsTab[randomMaterial];
        gm.floorNumber++;
        gm.howManyFloorsCurentlly++;
        spawningPlatfoprmHeight += randomY;
    }
}
