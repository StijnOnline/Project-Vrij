﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedNode : MonoBehaviour
{
    public float newSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cart")
        {
            GameManager.GM.cart.GetComponent<CartMovement>().speed = newSpeed;
        }
    }
}
