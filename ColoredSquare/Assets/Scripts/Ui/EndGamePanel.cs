using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    public GameManager gm;
    public Text pointsText;
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        pointsText.text = $"Zdobyte punkty: {gm.points}";
    }
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
