using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController Instance;



    private void Awake()
    {
        if (SceneController.Instance != null)
        {
            return;
        }
        Instance = this;



        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadNextScene()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReturnGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ReturnMainMenuScene()
    {
        SceneManager.LoadScene("Zero");
    }





}

