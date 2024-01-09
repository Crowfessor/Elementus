using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    public float Waterspeed;
    public GameObject Water;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Waterspeed * transform.parent.localScale.x, rb.velocity.y);
    }

    
    void Update()
    {
       Destroy(Water, 10f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.tag == "FireWall")
        {
            Destroy(Water, 0.1f);
        }
    }



}
