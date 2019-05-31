using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    public float speed = 0.5f;
    Rigidbody rigidB;
    public List<Transform> route = new List<Transform>();

    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
        //rididB.velocity = speed;
    }

    private void Update()
    {
        rigidB.velocity = (route[0].position - transform.position ).normalized * speed;
        rigidB.MoveRotation(Quaternion.LookRotation(rigidB.velocity, Vector3.up) * Quaternion.Euler(0,90,0));

        if ((route[0].position - transform.position ).magnitude < 1f)
        {
            route.RemoveAt(0);
        }
    }

}
