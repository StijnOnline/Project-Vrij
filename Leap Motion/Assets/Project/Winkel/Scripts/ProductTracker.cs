﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductTracker : MonoBehaviour
{
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        GameManager.GM.productAudioSource = GetComponent<AudioSource>();
        

        for (int i = 0;i< GameManager.GM.shoppingList.Count;i++)
        {
            amountText.text += GameManager.GM.amounts[i] + "\n";
            Product product = GameManager.GM.shoppingList[i].GetComponent<Product>();
            nameText.text += product.name + "\n";
            scoreText.text += product.score + "\n";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Product") {
            GameManager.GM.inCart.Add(other.gameObject);
        }
        if (other.transform.parent.tag == "Product")
        {
            GameManager.GM.inCart.Add(other.transform.parent.gameObject);
        }
        if (other.tag == "List")
        {
            other.GetComponent<RespawnList>().inCart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Product")
        {
            GameManager.GM.inCart.Remove(other.gameObject);
        }
        if (other.transform.parent.tag == "Product")
        {
            GameManager.GM.inCart.Remove(other.transform.parent.gameObject);
        }

        if (other.tag == "List")
        {
            other.GetComponent<RespawnList>().inCart = false;
        }
    }
}
