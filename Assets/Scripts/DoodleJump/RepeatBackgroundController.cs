using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundController : MonoBehaviour
{
    public Transform cameraPosition;
    public float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {        
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 1.2f;
    }

    
    void Update()
    {
        if (transform.position.y < cameraPosition.transform.position.y - repeatWidth)
        {
            transform.position = new Vector3(transform.position.x, cameraPosition.transform.position.y, transform.position.z);
        }
    }
}                                                        
