using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float FireSpeed;
    public float destroyTime;
    Animator ar;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
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
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "durak")
        {
            ar.SetTrigger("Hit");
            Destroy(gameObject,0.5f);
            rb.velocity = new Vector2(transform.localScale.x * 0.3f, 0);

        }

       
    }

}
