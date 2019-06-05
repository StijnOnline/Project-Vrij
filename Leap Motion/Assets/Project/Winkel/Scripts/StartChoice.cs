using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartChoice : MonoBehaviour
{
    public float delay = 1f;
    public float startTime = 0f;
    public List<string> choiceText;
    public List<Transform> left = new List<Transform>();
    public List<Transform> right = new List<Transform>();
    public enum Choices { Middle, Left, Right };
    public Choices choice;

    private void Update()
    {
        if (startTime != 0 && Time.time > startTime + delay)
        {
            CartMovement cartMovement = GameManager.GM.cart.GetComponent<CartMovement>();
            if (choice == Choices.Left) { cartMovement.route.Add(left[0]); }
            if (choice == Choices.Right) { cartMovement.route.Add(right[0]); }
            GameManager.GM.choiceDisplay.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {            
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
