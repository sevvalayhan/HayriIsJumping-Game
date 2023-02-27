using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    private float speed = 10;

    private Vector3 startPos1;
    private Vector3 startPos2;

    public Transform currentPoint;
    public GameObject platform;


    void Start()
    {
        startPos1 = new Vector3(Random.Range(-10,0), platform.transform.position.y, platform.transform.position.z);
        startPos2 = new Vector3(Random.Range(0,21), platform.transform.position.y, platform.transform.position.z);
    }


    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, startPos1, Time.deltaTime * speed);
        if (platform.transform.position==startPos1)
        {
            startPos1 = startPos2;
            startPos2 = platform.transform.position;
        }

        



    }
}
