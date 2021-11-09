using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor, floorCreated, pastFoor;
    public Transform player;
    public GameManager gm;
    public float spawningPlatfoprmHeight;
    public Renderer floorRenderer, playerRenderer, pastFloorRenderer;
    FloorBehavior floorBehavior;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        floorRenderer = floor.GetComponent<Renderer>();
        floorRenderer.material = gm.materialsTab[0];
        floorBehavior = floor.GetComponent<FloorBehavior>();
        playerRenderer = GameObject.Find("Player").GetComponent<Renderer>();
        pastFoor = floor;
        pastFloorRenderer = pastFoor.GetComponent<Renderer>();
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
            pastFloorRenderer.sharedMaterial = floorRenderer.sharedMaterial;
            if (gm.floorNumber % 50 != 0) // wlosowaniu koloru dodaæ ¿eby losowanie odpowiedniego koloru nastêpowa³o dopiero po tym gdy dla kostki zmieni siekolor
            {
                int randomMaterial = Random.Range(0, 3);
                floorRenderer.material = gm.materialsTab[randomMaterial];
                if (playerRenderer.material.name != "White (Instance)")
                {
                    if (floorRenderer.material != playerRenderer.material && floorRenderer.material == pastFloorRenderer.material)
                    {
                        int randomMaterialSecondDraw = Random.Range(0, 2);
                        if (randomMaterialSecondDraw == 0)
                            floorRenderer.material = gm.materialsTab[0];
                        else
                            floorRenderer.material = playerRenderer.material;
                    }
                }

            }
            else
                floorRenderer.material = gm.materialsTab[0];
        }
        floorCreated = Instantiate(floor, new Vector3(randomX, spawningPlatfoprmHeight, 0), Quaternion.identity);
        floorCreated.name = $"Floor{gm.floorNumber}";
        gm.floorNumber++;
        gm.howManyFloorsCurentlly++;
        spawningPlatfoprmHeight += randomY;
    }
}
