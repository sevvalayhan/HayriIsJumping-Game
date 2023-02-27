using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlScript : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBound();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kale"))
        {
            gameManager.UpdateScore(10);
            Destroy(gameObject);
        }

    }

    void DestroyOutOfBound()
    {
        if (transform.position.y - player.transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
