using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStart, isGameOver;
    public int howManyFloorsCurentlly, floorNumber;
    public Material[] materialsTab = new Material[3];

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
