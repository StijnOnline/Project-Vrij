using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform hand1;
    public Transform hand2;


    void Update()
    {
        //consider trying rigidbody movement

        if (hand1.gameObject.active && hand2.gameObject.active)
        {

            Debug.DrawLine(hand1.position, hand2.position, Color.red, Time.deltaTime);
            Debug.DrawLine(transform.position, transform.position + (hand1.forward + hand2.forward) / 2, Color.red, Time.deltaTime);


            transform.position = (hand1.position + (hand2.position - hand1.position) / 2);
            transform.rotation = Quaternion.LookRotation(hand2.position - hand1.position, (hand1.up + hand2.up) / 2);

            
            
        }
    }
}
