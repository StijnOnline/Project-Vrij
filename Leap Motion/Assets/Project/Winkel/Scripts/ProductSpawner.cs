using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    public int count = 5;
    public float offset = 0.2f;
    public Transform[] positions;
    [Space(10)]
    public GameObject[] products;
    

    void Start()
    {
        float pos = 0; 
        for (int i = 0; i<count; i++)
        {        
            foreach(Transform tr in positions)
            {
                GameObject ob = Instantiate(products[Random.Range(0, products.Length)], tr);
                ob.transform.position = tr.position + pos * tr.forward;
            }            
            pos += offset;
        }
    }

}