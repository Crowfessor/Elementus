using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireWall")
        {
            Destroy(gameObject);
        }
    }
}
