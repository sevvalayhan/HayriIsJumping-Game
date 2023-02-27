using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameManager gameManager;
    private AudioSource playerAudio;
    public AudioClip goalMusic;
    public int point = 20;
    private int goal = 1;
    public bool isGoal = false;
    // Start is called before the first frame update
    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);

            if (!isGoal)
            {
                gameManager.UpdateScore(point);
                gameManager.UpdateGoalsScore(goal);
                playerAudio.PlayOneShot(goalMusic);
                isGoal = true;
            }


        }
    }
}
