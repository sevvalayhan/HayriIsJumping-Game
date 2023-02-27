using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreenController : MonoBehaviour
{
    public void Update()
    {
    }
    public void RepeatButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Zero");
    }
       
}
