using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    public Vector3 speed = new Vector3(0.5f,0,0);
    Rigidbody rididB;

    void Start()
    {
        rididB = GetComponent<Rigidbody>();
        rididB.velocity = speed;
    }

}
