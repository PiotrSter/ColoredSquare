using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor;
    public Transform player;
    public int howManyFloor = 0;
    public float pastX = 0, pastY = 0;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
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
            floorWidth = floor.transform.localScale.x, x, y = 0; 
        floor.transform.localScale = new Vector3(sizeX, floor.transform.localScale.y, floor.transform.localScale.z);
        float beginningOfTheRangeY = pastY - floorHeight, endOfTheRangeY = pastY + floorHeight, beginningOfTheRangeX = pastX - floorWidth, endOfTheRangeX = pastX + floorWidth;
        if (randomY >= beginningOfTheRangeY && randomY <= endOfTheRangeY)
        {
            y = randomY + floorHeight * 2;
            Instantiate(floor, new Vector3(randomX, y, 0), Quaternion.identity);
            pastX = randomX;
            pastY = y;
        }
        /* else if (x >= beginningOfTheRangeX && x <= endOfTheRangeX && (y < beginningOfTheRangeY || y > endOfTheRangeY))
             Instantiate(floor, new Vector3(x + floorHeight * 2, y, 0), Quaternion.identity);
         else if (x >= beginningOfTheRangeX && x <= endOfTheRangeX && y >= beginningOfTheRangeY && y <= endOfTheRangeY)
             Instantiate(floor, new Vector3(x + floorHeight * 2, y + floorHeight * 2, 0), Quaternion.identity);*/
        else
        {
            Instantiate(floor, new Vector3(randomX, randomY, 0), Quaternion.identity);
            pastX = randomX;
            pastY = randomY;
        }
    }
}
