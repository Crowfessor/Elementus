using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public float distance = 10f;
    public int yansýmaSayýsý = 3;
    public RaycastHit2D hit;
    public LayerMask ayna;
  

    private LineRenderer lr;
    private Ray ray;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        
        
    }


    void Update()
    {

       


    }
    private void FixedUpdate()
    {
        Yansýyanlaser();
    }
    public void Yansýyanlaser()
    {
        ray = new Ray(transform.position,transform.right);

        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
       
        for (int i = 0; i < yansýmaSayýsý; i++)
        {
            if (Physics2D.Raycast(ray.origin, ray.direction,distance, ayna))
            {
                hit = Physics2D.Raycast(ray.origin, ray.direction, distance);

                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, hit.point);
               

                ray = new Ray(hit.point,Vector3.Reflect(ray.direction,hit.normal));
            }
            else
            {
                hit = Physics2D.Raycast(ray.origin, ray.direction, distance);
                if (hit.collider != null)
                {
                    lr.positionCount += 1;
                    lr.SetPosition(lr.positionCount - 1, hit.point);
                }
                else
                {
                    lr.positionCount += 1;
                    lr.SetPosition(lr.positionCount - 1, ray.origin + ray.direction * distance);
                }
 
            }
        }
        
    }


    public void normallaser()
    {
        lr.SetPosition(0, transform.position);
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
