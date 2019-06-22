using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnList : MonoBehaviour
{
    public bool inCart = true;
    public bool inHand = false;
    float lastTime = 0f;
    public float delay = 2f;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if(inCart || inHand)
        {
            lastTime = Time.time;
        }
        if (Time.time > lastTime + delay) { Respawn(); }
    }


    void Respawn()
    {
        Debug.Log("Respawn");
        transform.localPosition = startPos;
    }

    public void InHand(bool b)
    {
        inHand = b;
    }
}
