using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreScreenController : MonoBehaviour
{
    public TextMeshProUGUI viewScoreText;

    private GameManager gameManager;
    private float currentScore;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        currentScore = gameManager.score;
    }

    void Update()
    {
        ViewScore();
    }
    public void ViewScore()
    {
        
        viewScoreText.text = "Sonucunuz: " + currentScore.ToString();
    }
}
