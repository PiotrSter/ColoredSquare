using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStart, isGameOver, changeSpeed, wallGrows;
    public int floorNumber, points;
    public Material[] materialsTab = new Material[3];
    //public List<GameObject> listOfFloors = new List<GameObject>();

    void Awake()
    {
        floorNumber = 1;
        changeSpeed = false;
        points = 0;
        wallGrows = false;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
