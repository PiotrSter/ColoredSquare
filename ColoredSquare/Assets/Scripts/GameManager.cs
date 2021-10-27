using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStart, isGameOver;
    public List<GameObject> listOfFloor;
    public int howManyFloorsCurentlly;

    private void Awake()
    {
        howManyFloorsCurentlly = 0;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
