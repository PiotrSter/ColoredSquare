using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor, floorCreated;
    public Transform player;
    public GameManager gm;
    public float spawningPlatformHeight;
    public Renderer floorRenderer, playerRenderer;
    FloorBehavior floorBehavior;
    public PlayerMovment playerMovment;
    public bool canSpawn;

    public Transform Floors;
    public GameObject Spawner;
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
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < 50; i++)
            SpawnFloor();
    }

    private void SpawnFloor()
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
                if (gm.floorNumber < 151)
                {
                    int randomMaterial = Random.Range(0, 3);
                    if (playerMovment.randomMaterialNumber != 0)
                    {
                        if (gm.floorNumber % 2 == 0)
                        {
                            if (randomMaterial == 0)
                                floorRenderer.material = gm.materialsTab[0];
                            else
                            {
                                if (playerMovment.randomMaterialNumber == 1)
                                    floorRenderer.material = gm.materialsTab[1];
                                else if (playerMovment.randomMaterialNumber == 2)
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
                {
                    if (gm.floorNumber % 2 == 0)
                        floorRenderer.material = gm.materialsTab[1];
                    else
                        floorRenderer.material = gm.materialsTab[2];
                }

            }
            else
                floorRenderer.material = gm.materialsTab[0];
        }

        if((gm.floorNumber + 10) % 50 == 0)
            Instantiate(Spawner, new Vector3(randomX, spawningPlatformHeight, 0), Quaternion.identity, Floors);

        floorCreated = Instantiate(floor, new Vector3(randomX, spawningPlatformHeight, 0), Quaternion.identity, Floors);
        floorCreated.name = $"Floor{gm.floorNumber}";
        gm.floorNumber++;
        spawningPlatformHeight += randomY;
    }
}
