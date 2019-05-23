using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform hand1;
    public Transform hand2;
    public Transform camera;
    Quaternion startRotation;
    public float panMultiplier = 1f;
    void Start()
    {
        startRotation = camera.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float handAverage = hand1.position.z + (hand2.position.z - hand1.position.z) / 2;
        //Debug.Log(handAverage);
        Quaternion targetRotation = startRotation * Quaternion.Euler(Vector3.up * handAverage * panMultiplier);
        Debug.Log(targetRotation);
        camera.rotation = targetRotation;

    }
}
