using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selale : MonoBehaviour
{
    Animator ar;
    BoxCollider2D bc;
    GameObject player;
    GameObject su;
 
    void Start()
    {
        ar = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        su = GameObject.FindWithTag("yersu");
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<hareket>().KnockBack();
        }
        else if (collision.gameObject.tag == "Waterball")
        {
            Destroy(collision.gameObject);
            gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            StartCoroutine(Timer());
        }
        else if (collision.gameObject.tag == "Airball")
        {
            player.GetComponent<SPELL>().timer = 2.5f;
            Destroy(collision.gameObject);
            ar.SetTrigger("don");
            bc.enabled = false;

        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(1, 1, 1);

    }
    public void dondur()
    {
        su.GetComponent<Animator>().SetTrigger("don");
    }
}
