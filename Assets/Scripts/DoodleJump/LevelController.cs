using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int levelGenerator = 1;
    public GameManager gameManager;
    public CameraFollowControler mainCamera;
    public Platform platform;
    private int currentScore; 
    float platformJumpForce;
  
    void Start()
    {       
        currentScore = 50;

        platformJumpForce = platform.jumpForce;
    }

    
    void Update()
    {
        if (gameManager.score == currentScore)
        {
            levelGenerator++;
            platformJumpForce = platformJumpForce * 1.7f;
            mainCamera.speed *= 1.7f;
            currentScore = currentScore + 50;
            Debug.Log($"Level {levelGenerator}");

        }
    }
}
