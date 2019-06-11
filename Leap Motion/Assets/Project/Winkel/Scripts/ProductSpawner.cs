using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    public int count = 5;
    public Vector3 offset = new Vector3(0.2f,0,0);
    public Transform[] positions;
    [Space(10)]
    public GameObject[] products;
    

    void Start()
    {
        Vector3 pos = new Vector3(0,0,0); 
        for (int i = 0; i<count; i++)
        {
            GameObject product = products[Random.Range(0, products.Length)];            
            foreach(Transform tr in positions)
            {
                GameObject ob = Instantiate(product, tr);
                ob.transform.position = tr.position + pos;
            }            
            pos += offset;
        }
    }

}