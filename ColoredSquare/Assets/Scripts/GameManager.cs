using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameStart, isGameOver, changeSpeed, wallGrows;
    public int floorNumber, points;
    public Material[] materialsTab = new Material[3];
    public GameObject endGamePanel;
    public Text scoreText;

    void Awake()
    {
        isGameOver = false;
        floorNumber = 1;
        changeSpeed = false;
        points = 0;
        wallGrows = false;
    }

    void Update()
    {
        if (isGameOver)
            endGamePanel.SetActive(true);

        scoreText.text = $"Score: {points}";
    }
}
