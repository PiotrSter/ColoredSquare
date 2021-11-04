using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStart, isGameOver, changeSpeed;
    public int howManyFloorsCurentlly, floorNumber;
    public Material[] materialsTab = new Material[3];

    private void Awake()
    {
        howManyFloorsCurentlly = 0;
        floorNumber = 1;
        changeSpeed = false;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
