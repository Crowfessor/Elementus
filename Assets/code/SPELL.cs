using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SPELL : MonoBehaviour
{
    public GameObject Fireball;
    public GameObject Player;
    public Transform rangeattack;


    Rigidbody2D rb;
    Animator ar;
    hareket ph;

    public float timer;
    public float timerSet;
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
            StoneWall();
            SpellSkill();
        }

        if (!ph.canMove)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            ph.ControlMove(true);
            timer = timerSet;
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
    }
    public void SpellSkill()
    {
        switch (CurrentPower)
        {
            case 0:
                FireBall();
                break;

            case 1:
                
                break;


        }
    }
    public void FireBall()
    {
        if (Input.GetMouseButtonDown(0) && ph.canMove)
        {

            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("FireAttack");
        

           ar.SetTrigger("FireAttack");
           GameObject fire =  Instantiate(Fireball, rangeattack.position, Fireball.transform.rotation);
           Vector3 origscale = fire.transform.localScale;

            fire.transform.localScale = new Vector3 (
                origscale.x * transform.localScale.x > 0 ? 10 : -10,
                origscale.y,
                origscale.z
                );

        }


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
   
   
    public void StoneWall()
    {
        
        if (Input.GetKeyDown(KeyCode.S) && ph.canMove)
        {
            
            rb.velocity = Vector2.zero;
            ph.ControlMove(false);
            ar.SetTrigger("StoneWall");

          
        }
       
    }
}
