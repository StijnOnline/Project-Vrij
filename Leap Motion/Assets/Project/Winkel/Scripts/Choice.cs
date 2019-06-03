using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{

    public CameraLook camLook;
    public enum Choices { Middle,Left,Right};
    public Choices choice;
    public float delay = 1f;

    private void Awake()
    {
        camLook.pan = false;
    }
}
