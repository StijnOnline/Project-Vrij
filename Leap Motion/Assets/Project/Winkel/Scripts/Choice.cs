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
    public float startTime = 0f;
    public CartMovement cart;

    public List<Transform> left = new List<Transform>();
    public List<Transform> right = new List<Transform>();

    private void Awake()
    {
        camLook.pan = false;
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > startTime + delay)
        {
            if(choice == Choices.Left) { cart.route.AddRange(left); }
            if (choice == Choices.Right) { cart.route.AddRange(right); }
            gameObject.SetActive(false);
        }
    }
}
