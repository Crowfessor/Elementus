using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image HealtBar;

    public float Health = 6;
    public int HalfCounter;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void Healthchange(float HealthchangeValue)
    {
        Health -= HealthchangeValue;
        if(Health % 2 == 0 && Health !=6)
        {
            HalfCounter = 2;
        }
        else
        {
            HalfCounter = 0;
        }
     
        HealthchangeValue = (3.5f * HealthchangeValue + HalfCounter) / 25;
        HealtBar.fillAmount -= HealthchangeValue;


    }
}
