using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float FireSpeed;
    public float destroyTime;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = new Vector2 (FireSpeed * transform.localScale.x, 0);
    }
    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stone")
            Destroy(gameObject);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stone")
            Destroy(gameObject);
    }

}
