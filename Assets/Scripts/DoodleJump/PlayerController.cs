using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Slider slider;
    public GameObject projectilePrefab;
    public GameManager gameManager;
    public EnergySlider sliderScript;

    [SerializeField] GameObject CameraObject;
    private SceneController sceneController;



    private AudioSource playerAudio;
    public AudioClip ballSound;
    public List<AudioClip> eatingSounds;



    private float movementSpeed = 15;
    private float movement = 0;
    private int pointValue;
    private int xBoundRight = 29;
    private int xBoundLeft = -16;

    Rigidbody2D rb;

    [SerializeField] Sprite hayriShooting;
    [SerializeField] Sprite hayriIdle;
    [SerializeField] Sprite hayriFlying;

    float cooldown = .5f;
    float lastShot;



   
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pointValue = 1;

    }
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (transform.position.x < xBoundLeft)
        {
            transform.position = new Vector3(xBoundRight, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundRight)
        {
            transform.position = new Vector3(xBoundLeft, transform.position.y, transform.position.z);
        }

        if (sliderScript.slider.value.Equals(0))
        {
            gameManager.GameOver();
        }

        HayriShoots();

        if ((projectilePrefab.transform.position.y) - (transform.position.y) > 25)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }



    }

    private void HayriShoots()
    {
        Vector3 offset = transform.position + new Vector3(2, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShot > cooldown)
            {
                lastShot = Time.time;

                StartCoroutine(SpriteChangingCoroutine(.15f));
                Instantiate(projectilePrefab, offset, projectilePrefab.transform.rotation);
                playerAudio.PlayOneShot(ballSound);
            }
        }

    }

    //public void HayriFellsOff()
    //{
    //    float lerpSpeed = 2f;
    //    //Vector3 lastJumpPosition = transform.position + new Vector3(0, 15, 0);
    //    //Vector3 lastGlidePosition = transform.position + new Vector3(0, -30, 0);
    //    GetComponent<SpriteRenderer>().sprite = hayriFlying;

    //    transform.position = Vector3.Lerp(CameraObject.transform.position, transform.position, Time.deltaTime * lerpSpeed);

    //}
    IEnumerator SpriteChangingCoroutine(float waitingSeconds)
    {
        GetComponent<SpriteRenderer>().sprite = hayriShooting;
        yield return new WaitForSeconds(waitingSeconds);
        GetComponent<SpriteRenderer>().sprite = hayriIdle;

    }
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var eatingSoundsCount = eatingSounds.Count;
        if (collision.gameObject.CompareTag("SucukEkmek"))
        {
            playerAudio.PlayOneShot(eatingSounds[Random.Range(0, eatingSoundsCount)]);
            sliderScript.UpGrade(5);
            Destroy(collision.gameObject);

        }

    }
}
