using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBall : MonoBehaviour
{
    Rigidbody2D rb;
    public float AirSpeed;
    GameObject obje;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }
    void Start()
    {
       
        rb.velocity = new Vector2(AirSpeed * transform.localScale.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FireWall")
        {
            obje = collision.gameObject;
            collision.gameObject.GetComponent<Transform>().localScale = new Vector3(15,15,15);
            StartCoroutine(Timer());
            
            
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        obje.gameObject.GetComponent<Transform>().localScale = new Vector3(11, 11, 11);
        Destroy(gameObject, 0.01f);
    }
}
