using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPELL : MonoBehaviour
{
    public GameObject Fireball;
    public Transform rangeattack;
    Animator ar;
    public int CurrentPower = 0;
    void Start()
    {
        ar = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        KeyBinds();
        SpellSkill();
    }
    public void KeyBinds()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentPower = 0;
        }
    }
    public void SpellSkill()
    {
        switch (CurrentPower)
        {
            case 0:
                FireBall();
                break;
        }
    }
    public void FireBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
}
