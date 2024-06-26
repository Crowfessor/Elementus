using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public float distance = 10f;
    public int yansımaSayısı;
    public RaycastHit2D hit;
    public LayerMask ayna;
    GameObject durak2;

    private LineRenderer lr;
    private Ray ray;

    public bool İspanel;

    public float timer;
    public float Timerset;
    void Start()
    {
        İspanel = false;
        timer = Timerset;
        lr = GetComponent<LineRenderer>();
        yansımaSayısı = 4;
        durak2 = GameObject.FindGameObjectWithTag("durak2");

    }


    void Update()
    {

        if (İspanel && timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else if(!İspanel)
        {
            timer = Timerset;
        }


        if (timer <= 0)
        {
            Destroy(durak2);
        }

    }
    private void FixedUpdate()
    {
        Yansıyanlaser();
    }
    public void Yansıyanlaser()
    {
        ray = new Ray(transform.position,transform.right);

        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
       
        for (int i = 0; i < yansımaSayısı; i++)
        {
            if (Physics2D.Raycast(ray.origin, ray.direction, distance, ayna))
            {
                hit = Physics2D.Raycast(ray.origin, ray.direction, distance);
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, hit.point);


                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
            }
            else
            {
                hit = Physics2D.Raycast(ray.origin, ray.direction, distance);
                if (hit.collider != null && hit.collider.gameObject.tag != "panel")
                {
                    lr.positionCount += 1;
                    lr.SetPosition(lr.positionCount - 1, hit.point);
                    İspanel = false;
                }
                else if (hit.collider != null && hit.collider.gameObject.tag == "panel") 
                {
                    lr.positionCount += 1;
                    lr.SetPosition(lr.positionCount - 1, hit.point);
                    İspanel = true;
                }
                else
                {
                    İspanel = false;
                    lr.positionCount += 1;
                    lr.SetPosition(lr.positionCount - 1, ray.origin + ray.direction * distance);
                    Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.green);
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
