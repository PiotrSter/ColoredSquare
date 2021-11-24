using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor, floorCreated;
    public Transform player;
    public GameManager gm;
    public float spawningPlatformHeight;
    public Renderer floorRenderer, playerRenderer, pastFloorRenderer;
    FloorBehavior floorBehavior;
    public PlayerMovment playerMovment;
    public int test;
    public bool canSpawn;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerMovment = GameObject.Find("Player").GetComponent<PlayerMovment>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        floorRenderer = floor.GetComponent<Renderer>();
        floorRenderer.material = gm.materialsTab[0];
        floorBehavior = floor.GetComponent<FloorBehavior>();
        playerRenderer = GameObject.Find("Player").GetComponent<Renderer>();
        spawningPlatformHeight = -2f;
        canSpawn = false;
        for (int i = 0; i < 50; i++)
            SpawnFloor();
    }

    void Update()
    {
        if (canSpawn)
        {
            for (int i = 0; i < 50; i++)
                SpawnFloor();

            canSpawn = false;
        }
    }

    void SpawnFloor()
    {
        float randomX, randomY, sizeX;

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
        floorBehavior.number = gm.floorNumber;
        if (gm.floorNumber > 50)
        {
            if (gm.floorNumber % 50 != 0) 
            {
                int randomMaterial = Random.Range(0, 3);
                if (playerMovment.randomMaterial != 0)
                {
                    if (gm.floorNumber % 2 == 0)
                    {
                        if (randomMaterial == 0)
                            floorRenderer.material = gm.materialsTab[0];
                        else
                        {
                            if (playerMovment.randomMaterial == 1)
                                floorRenderer.material = gm.materialsTab[1];
                            else if (playerMovment.randomMaterial == 2)
                                floorRenderer.material = gm.materialsTab[2];
                        }
                    }
                    else
                        floorRenderer.material = gm.materialsTab[randomMaterial];
                }
                else
                    floorRenderer.material = gm.materialsTab[randomMaterial];

            }
            else
                floorRenderer.material = gm.materialsTab[0];
        }
        floorCreated = Instantiate(floor, new Vector3(randomX, spawningPlatformHeight, 0), Quaternion.identity);
        floorCreated.name = $"Floor{gm.floorNumber}";
        //gm.listOfFloors.Add(floorCreated);
        gm.floorNumber++;
        spawningPlatformHeight += randomY;
    }
}
