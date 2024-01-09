using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SPELL : MonoBehaviour
{
    public GameObject Fireball;
    public GameObject Airball;
    public GameObject StoneWallSpawn;
    public Transform rangeattack;

    Rigidbody2D rb;
    Animator ar;
    hareket ph;

    public float timer;
    public float timerSet;

    public bool dead;


    public int CurrentPower = 0;
    void Start()
    {
        ar = GetComponent<Animator>();
        ph = GetComponent<hareket>();
        rb = GetComponent<Rigidbody2D>();

        timerSet = 1;
    }

    // Update is called once per frame
    void Update()
    {
        KeyBinds();
       
        if(!ph.OnWall() && ph.IsGrounded() )
        {
            StoneWallTriger();
            SpellSkill();
        }

        if (!ph.canMove)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && !dead)
        {
            ph.ControlMove(true);
            timer = timerSet;
        }

    }
    public void isdead(bool d)
    {
        if (d == true)
        {
            dead = true;
        }
        else
        {
            dead = false;
        }
    }
    public void KeyBinds()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentPower = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentPower = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentPower = 2;
        }
    }
    public void SpellSkill()
    {
        switch (CurrentPower)
        {
            case 0:
                Firemove();
                break;

            case 1:
                Airmove();
                break;

            case 2:
                WaterAttack();
                break;


        }
    }
    public void Firemove()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("FireAttack");
        
        }


    }


    public void Airmove()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {
            timer = 1.5f;
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("AirAttack");


        }
       

    }

    public void WaterAttack()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {
            timer = 1.5f;
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("WaterAttack");


        }
    }
    public void AirAttack()
    {

        GameObject Air = Instantiate(Airball, rangeattack.position, Airball.transform.rotation);
        Vector3 origscale = Air.transform.localScale;

        Air.transform.localScale = new Vector3(
            origscale.x * transform.localScale.x > 0 ? 5 : -5,
            origscale.y,
            origscale.z
            );
    }

    public void FireAttack()
    {
        GameObject fire = Instantiate(Fireball, rangeattack.position, Fireball.transform.rotation);
        Vector3 origscale = fire.transform.localScale;

        fire.transform.localScale = new Vector3(
            origscale.x * transform.localScale.x > 0 ? 10 : -10,
            origscale.y,
            origscale.z
            );
       
    }
   
   
    public void StoneWallTriger()
    {
        
        if (Input.GetKeyDown(KeyCode.S) && ph.canMove)
        {
            timer = 1.5f;
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("StoneWall");

          
        }
       
    }
    public void StoneWallOn()
    {
        StoneWallSpawn.SetActive(true);
    }
    public void StoneWallOf()
    {
        StoneWallSpawn.SetActive(false);
    }
}
