﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    Transform hand1;
    Transform hand2;
    public GameObject leftHandTracked;
    public GameObject rightHandTracked;

    public List<Behaviour> enableList = new List<Behaviour>();
    public List<GameObject> disableList = new List<GameObject>();

    private void Start()
    {
        hand1 = GameManager.GM.hand1;
        hand2 = GameManager.GM.hand2;
    }

    void Update()
    {
        leftHandTracked.SetActive(hand1.gameObject.activeSelf);
        rightHandTracked.SetActive(hand2.gameObject.activeSelf);

        if (hand1.gameObject.activeSelf && hand2.gameObject.activeSelf)
        {
            foreach(Behaviour c in enableList)
            {                
                c.enabled = true;
            }
            foreach (GameObject g in disableList)
            {
                g.SetActive(false);
            }
            this.enabled = false;
        }
    }
}
