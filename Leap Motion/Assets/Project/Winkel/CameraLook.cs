using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform hand1;
    public Transform hand2;
    public Transform camera;
    public float panMultiplier = 1f;
    

    void Update()
    {

        if (hand1.gameObject.activeSelf || hand2.gameObject.activeSelf)
        {
            float handAverage = 0f;
            if (hand1.gameObject.activeSelf && !hand2.gameObject.activeSelf) { handAverage = hand1.position.z; }
            if (!hand1.gameObject.activeSelf && hand2.gameObject.activeSelf) { handAverage = hand2.position.z; }
            if (hand1.gameObject.activeSelf && hand2.gameObject.activeSelf) { handAverage = hand1.position.z + (hand2.position.z - hand1.position.z) / 2; }

            Quaternion targetRotation =  Quaternion.Euler(Vector3.up * handAverage * panMultiplier) * Quaternion.Euler(0,-90,0);
            camera.localRotation = targetRotation;
                       
        }
    }
}
