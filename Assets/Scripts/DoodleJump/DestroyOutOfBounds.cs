using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameObject player;
    private EnergySlider energySlider;

    private void Awake()
    {
        player = GameObject.Find("Hayri");
    }
    private void Update()
    {   
       CheckPosition();

    }
    private void CheckPosition()
    {
        bool isFarAway = transform.position.y - player.transform.position.y > 35;

        if (isFarAway)
        {
            Destroy(gameObject);
        }
    }
   
}
