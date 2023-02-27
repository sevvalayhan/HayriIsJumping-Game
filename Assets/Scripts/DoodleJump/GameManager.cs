using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Newtonsoft.Json.Bson;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goalText;
    public TextMeshProUGUI sonucTex;
    public TextMeshProUGUI sonucGoalsText;


    
    public GameObject gameOverScreen;
    private bool isGameActive=true;
    private int currentScore;

    public int score;
    int goal;


  
    void Update()
    {

        currentScore = score;
        if (isGameActive==true)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Puan: " + currentScore.ToString();
    }
    public void UpdateGoalsScore(int value)
    {
        goal += value;
        score += value;
        goalText.text = "Gol sayisi: " + goal.ToString();
    }


    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        sonucTex.text = "Puaniniz: " + score.ToString();
        sonucGoalsText.text = "Gol Sayisi: " + goal.ToString();

      
        isGameActive = false;

        if (isGameActive==false)
        {
            Time.timeScale = 0;
        }

    }
    public void RestartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        if (isGameActive)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1;
        SceneController.Instance.LoadNextScene();

    }



}
