using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor, floorCreated, pastFloor;
    public Transform player;
    public GameManager gm;
    public int howManyFloor = 0, floorNumber = 1;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnFloor();
        SpawnFloor();
        SpawnFloor();

        /*
         Tu trzeba bedize chyba dodawaæ platformy do listy i sprawdzaæ, czy wspólrzedne tych platform nie nachodz¹ na siebie jeœli tak to jes przesuwaæ
         */
    }

    void Update()
    {
        
    }

    void SpawnFloor()
    {
        float randomX = Random.Range(-8f, 8f), randomY = Random.Range(player.transform.position.y + 1, player.transform.position.y + 5), sizeX = Random.Range(1f, 8.5f), floorHeight = floor.transform.localScale.y,
            floorWidth = floor.transform.localScale.x; 
        floor.transform.localScale = new Vector3(sizeX, floor.transform.localScale.y, floor.transform.localScale.z);
        floorCreated = Instantiate(floor, new Vector3(randomX, randomY, 0), Quaternion.identity);
        floorCreated.name = $"Floor{floorNumber}";
        floorNumber++;
        gm.listOfFloor.Add(floorCreated);
    }
}
