using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("oof");
        if (collision.gameObject.tag == "Cart")
        {
            Debug.Log("ouch");
            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = false;
            }
            GetComponent<Collider>().enabled = false;
        }
    }
}
