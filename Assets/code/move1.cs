using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move1 : MonoBehaviour
{
    Rigidbody2D rb;

    Animator ar;
   
    public Button b1;
    public Button b2;
    public Button b3;

    public GameObject canvas;
    public GameObject secim;

    public float speed;
    void Start()
    {
        speed = 100f;

        ar = GetComponent<Animator>();

        canvas = GameObject.FindWithTag("UI");
        secim = GameObject.FindWithTag("secim");

        b1 = GameObject.FindWithTag("B1").GetComponent<Button>();
        b2 = GameObject.FindWithTag("B2").GetComponent<Button>();
        b3 = GameObject.FindWithTag("B3").GetComponent<Button>();

        b1.onClick.AddListener(delegate { Secim(0); });
        b2.onClick.AddListener(delegate { Secim(1); });
        b3.onClick.AddListener(delegate { Secim(2); });

        rb = GetComponent<Rigidbody2D>();

        secim.SetActive(false);
    }


    void Update()
    {
        ar.SetBool("run", speed != 0);
    }
    private void FixedUpdate()
    {
        
        if (this.GetComponent<hareket>().horizontal == 0 && this.GetComponent<hareket>().canMove)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        
        
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "durak")
        {
            speed = 0f;
            secim.SetActive(true);
        }
    }

    public void Secim(int i)
    {
        this.GetComponent<hareket>().canMove = false;
        if (i == 0)
        {
            ar.SetTrigger("FireAttack");
            secim.SetActive(false);
        }
        else if (i == 1)
        {
            ar.SetTrigger("AirAttack");
            secim.SetActive(false);
        }
        else if (i == 2)
        {
            ar.SetTrigger("WaterAttack");
            secim.SetActive(false);
            speed = 100f;
        }
       
    }
}
