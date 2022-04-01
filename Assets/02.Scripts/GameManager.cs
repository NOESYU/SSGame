using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameoverUI;
    public GameObject playerLife;
    public GameObject playerLifeChild;
    public GameObject menuPanel;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Game Manger 2개이상 존재");
            Destroy(gameObject);
        } 
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = score.ToString();
        }
    }

    public void OnPlayerDead()
    {
        
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void MinusLife(int newLife)
    {
        playerLifeChild = playerLife.transform.GetChild(newLife).gameObject;
        playerLifeChild.SetActive(false);
    }
    public void OnClickReStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void OnCickExitButton()
    {
        Application.Quit();
    }

    public void OnClickMenuButton()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ClickeMenuPanel()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public int GetScore()
    {
        return score;
    }
}
