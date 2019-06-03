using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool pan = true;

    public Transform hand1;
    public Transform hand2;
    public Transform camera;
    public float panMultiplier = 1f;    

    void Update()
    {
        float handAverage = 0f;
        if (pan && hand1.gameObject.activeSelf || hand2.gameObject.activeSelf)
        {            
            if (hand1.gameObject.activeSelf && !hand2.gameObject.activeSelf) { handAverage = hand1.localPosition.x; }
            if (!hand1.gameObject.activeSelf && hand2.gameObject.activeSelf) { handAverage = hand2.localPosition.x; }
            if (hand1.gameObject.activeSelf && hand2.gameObject.activeSelf) { handAverage = hand1.localPosition.x + (hand2.localPosition.x - hand1.localPosition.x) / 2; }           
        }

        Quaternion targetRotation = Quaternion.Euler(Vector3.up * handAverage * panMultiplier) * Quaternion.Euler(20, -90, 0);
        camera.localRotation = targetRotation;
    }
}
