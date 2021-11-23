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
    //public int drawOtherColorToFloor; // zmienna pomaga okreœliæ czy platformy mog¹ zostaæ losowane w innym, kolorze, mog¹ dopiero gdy dla gracza zmienia siê kolor
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
        //drawOtherColorToFloor = 0;
        for (int i = 0; i < 20; i++)
        {
            SpawnFloor(); // zwiekszysc predkosc spawnowania
        }
    }

    void Update()
    {
        test = gm.listOfFloors.Count;
        if (gm.listOfFloors.Count < 50)
            SpawnFloor();
    }

    void SpawnFloor()
    {
        float randomX, randomY, sizeX;

        if (gm.floorNumber % 20 != 0)
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
            if (gm.floorNumber % 50 != 0) // wlosowaniu koloru dodaæ ¿eby losowanie odpowiedniego koloru nastêpowa³o dopiero po tym gdy dla kostki zmieni siekolor
            {
                int randomMaterial = Random.Range(0, 3);
                if (playerRenderer.material.name != "White (Instance)")
                {
                    if (gm.floorNumber % 2 == 0)
                    {
                        floorRenderer.material = gm.materialsTab[0];
                        /*if (randomMaterial == 0)
                            floorRenderer.material = gm.materialsTab[0];
                        else
                        {
                            if (playerRenderer.material.name != "Red (Instance)")
                                floorRenderer.material = gm.materialsTab[1];
                            else if (playerRenderer.material.name != "Blue (Instance)")
                                floorRenderer.material = gm.materialsTab[2];
                        }*/
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
        gm.listOfFloors.Add(floorCreated);
        gm.floorNumber++;
        gm.canSpawn = false;
        spawningPlatformHeight += randomY;
    }
}
