using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    public List<GameObject> products;
    public int count = 5;
    public Vector3 offset = new Vector3(0.2f,0,0);

    void Start()
    {
        Vector3 pos = new Vector3(0,0,0); 
        for (int i = 0; i<count; i++)
        {
            GameObject product = products[Random.Range(0, products.Count)];
            GameObject ob = Instantiate(product, transform);
            ob.transform.position = transform.position + pos;
            pos += offset;
        }
    }

}
