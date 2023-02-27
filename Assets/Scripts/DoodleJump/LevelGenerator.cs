using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> platforms;
    public int numberOfPlatforms = 1000;
    private float minY = 11f;
    private float maxY = 14.10f; 
    private float levelWidth = 16;
     void Start()
    {
        SpawnPlatform();
    }    void SpawnPlatform()
    {
        Vector3 spawnPositon = new Vector3();
        for (int i = 0; i < 1000; i++)
        {
            spawnPositon.y += Random.Range(minY, maxY);
            spawnPositon.x = Random.Range(-levelWidth, levelWidth);
            var ratio = Random.Range(0, 230);
            if (ratio < 120)
            {
                Instantiate(platforms[0], spawnPositon, Quaternion.identity);
            }
            else if (120 < ratio && ratio < 170)
            {
                Instantiate(platforms[1], spawnPositon, Quaternion.identity);
            }
            else if (170 < ratio && ratio < 185)
            {
                Instantiate(platforms[2], spawnPositon, Quaternion.identity);
            }
            else if (185 < ratio && ratio < 195)
            {
                Instantiate(platforms[3], spawnPositon, Quaternion.identity);
                Instantiate(platforms[0], new Vector3(spawnPositon.x + 20, spawnPositon.y), Quaternion.identity);
            }
            else if (195 < ratio && ratio < 200)
            {
                Instantiate(platforms[4], spawnPositon, Quaternion.identity);
            }
            else 
            {
                Instantiate(platforms[5], spawnPositon, Quaternion.identity);
            }
           

        }
    }
    
}
