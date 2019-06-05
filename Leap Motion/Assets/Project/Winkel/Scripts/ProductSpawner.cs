using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    public int count = 5;
    public Vector3 offset = new Vector3(0.2f,0,0);

    void Start()
    {
        Vector3 pos = new Vector3(0,0,0); 
        for (int i = 0; i<count; i++)
        {
            GameObject product = GameManager.GM.allProducts[Random.Range(0, GameManager.GM.allProducts.Count)];
            GameObject ob = Instantiate(product, transform);
            ob.transform.position = transform.position + pos;
            pos += offset;
        }
    }

}