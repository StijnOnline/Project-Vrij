using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    Rigidbody rigidB;

    public float speed = 0.5f;
    public float smoothValue = 0.05f; 
    public List<Transform> route = new List<Transform>();

    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (route.Count > 0)
        {
            rigidB.velocity = (route[0].position - transform.position).normalized * speed;
            Quaternion targetRotation = Quaternion.LookRotation(rigidB.velocity, Vector3.up) * Quaternion.Euler(0, 90, 0);
            rigidB.MoveRotation(Quaternion.Lerp(rigidB.rotation, targetRotation, smoothValue));

            if ((route[0].position - transform.position).magnitude < 0.1f)
            {
                route.RemoveAt(0);
            }
        }
    }

}