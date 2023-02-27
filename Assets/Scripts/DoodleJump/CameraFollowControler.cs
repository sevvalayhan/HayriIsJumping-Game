using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollowControler : MonoBehaviour
{
    public GameOverScreenController gameOverScreenController;
    public Platform platform;
    public GameManager gameManager;
    private SceneController sceneController;

    public float smoothSpeed = 3;
    public float speed = 4;

    public GameObject player;
    private AudioSource playerAudio;
    public AudioClip deadingSound;


    bool isPlayerFallen;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();

    }


    void Update()
    {


        if (!isPlayerFallen)
        {

            Debug.Log("Worked!");
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }



        if (player.transform.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = newPos;


        }

        if (transform.position.y - player.transform.position.y > 25)
        {
            isPlayerFallen = true;
            playerAudio.PlayOneShot(deadingSound);
            gameManager.GameOver();

        }
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

    }


}
