using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject player;
    public float jumpForce;
    public Rigidbody2D rb;
    public GameManager gameManager;
    private bool isPointsGiven = false;

    private AudioSource playerAudio;
    public AudioClip crackingSound;
    public AudioClip trambolineSound;


    private EnergySlider sliderScript;

    private int fallingSpeed = 2;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        sliderScript = GameObject.Find("Hayri").GetComponent<EnergySlider>();
        playerAudio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if ((player.transform.position.y) - (transform.position.y) > 30)//player destroy
        {
            Destroy(gameObject);
        }

        if ((player.transform.position.y > transform.position.y) && !isPointsGiven)
        {
            gameManager.UpdateScore(1);
            sliderScript.DownGrade(1);
            isPointsGiven = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {


            rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
            if (gameObject.name.Contains("Trambolin"))
            {
                playerAudio.PlayOneShot(trambolineSound);
            }
            if (gameObject.name.Contains("Falling"))
            {
                transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);
                GetComponent<Animator>().SetTrigger("Collision");
                playerAudio.PlayOneShot(crackingSound);
                isPointsGiven = false;


            }
        }



    }

    private void AddPoints(int value)
    {
        gameManager.UpdateScore(value);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hayri")
        {
            GetComponent<Collider2D>().isTrigger = false;

        }
    }




}
