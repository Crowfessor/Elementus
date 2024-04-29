using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donme : MonoBehaviour
{
   
    public Vector3 a;
    public GameObject donen;
    public int t;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        Vector3 a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        this.transform.rotation = Quaternion.Euler(0, 0, a.x * 10);
    }
}
