using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dogruluk : MonoBehaviour
{
    public int i1, i2, i3, i4, i5, i6;
    GameObject[] images;
    void Start()
    {
        images = GameObject.FindGameObjectsWithTag("images");
    }

   
    void Update()
    {
        Dogrumu();
    }
    public void Dogrumu()
    {
        if (i1 + i2 == 3)
        {
            Renkler(i1,i2);
        }

        if (i3 + i4 == 7)
        {
            Renkler(i3,i4);
        }
    }
    public void Renkler(int k,int k1)
    {
        foreach (var item in images)
        {
            if (item.name == "Image" + k || item.name == "Image" + k1)
            {
                item.GetComponent<Image>().color = Color.green;

            }
        };
    }
}
