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
    }

    private void Update()
    {
        if (route.Count > 0)
        {
            rigidB.velocity = (route[0].position - transform.position).normalized * speed;
            Quaternion targetRotation = Quaternion.LookRotation(rigidB.velocity, Vector3.up) * Quaternion.Euler(0, 90, 0);
            rigidB.MoveRotation(Quaternion.Lerp(rigidB.rotation, targetRotation, 0.05f));

            if ((route[0].position - transform.position).magnitude < 0.1f)
            {
                route.RemoveAt(0);
            }
        }
    }

}