using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public float distance = 10f;
    private LineRenderer lr;
    

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0,transform.position);
        
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hit.collider != null)
        {
            
            Debug.DrawLine(transform.position, hit.point, Color.green);
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.SetPosition(1, transform.position + transform.right * distance);
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.red);
        }
        
        

    }
  
}
