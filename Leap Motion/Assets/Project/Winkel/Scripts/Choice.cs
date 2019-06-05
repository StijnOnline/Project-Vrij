using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{

    public StartChoice startChoice;

    public CameraLook camLook;
    public enum Choices { Middle,Left,Right};
    public Choices choice;
    public float delay = 1f;
    public float startTime = 0f;

    public CartMovement cart;

    private void Awake()
    {
        camLook.pan = false;
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > startTime + delay)
        {
            if(choice == Choices.Left) { cart.route.Add(startChoice.left[0]); }
            if (choice == Choices.Right) { cart.route.Add(startChoice.right[0]); }
            gameObject.SetActive(false);
        }
    }
}
