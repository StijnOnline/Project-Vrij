﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartChoice : MonoBehaviour
{
    public float delay = 1f;
    public float startTime = 0f;
    [Space(10)]
    public List<string> choiceText;
    public List<Transform> left = new List<Transform>();
    public List<Transform> right = new List<Transform>();
    
    public enum Choices { Middle, Left, Right };
    [Space(10)]
    public Choices choice;

    private void Update()
    {
        if (startTime != 0 && Time.time > startTime + delay)
        {
            GameManager.GM.cartCamera.GetComponent<CameraLook>().pan = true;
            CartMovement cartMovement = GameManager.GM.cart.GetComponent<CartMovement>();
            if (choice == Choices.Left) { cartMovement.route.AddRange(left); }
            if (choice == Choices.Right) { cartMovement.route.AddRange(right); }
            GameManager.GM.choiceDisplay.SetActive(false);
            startTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {
            //disable objects in cart (save)
            foreach(GameObject g in GameManager.GM.inCart)
            {
                g.SetActive(false);
            }

            GameManager.GM.currentChoice = gameObject;
            GameManager.GM.choiceDisplay.SetActive(true);
            for (int i = 0; i< 3; i++)
            {
                Transform child = GameManager.GM.choiceDisplay.transform.GetChild(i);
                TextMeshPro t = child.GetComponentInChildren<TextMeshPro>();
                t.SetText(choiceText[i]);                
            }
            
            GameManager.GM.cartCamera.GetComponent<CameraLook>().pan = false;
            startTime = Time.time;

            GetComponent<Collider>().enabled = false;
        }
    }


}
