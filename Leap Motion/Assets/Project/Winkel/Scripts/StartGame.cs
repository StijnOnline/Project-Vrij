using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;

public class StartGame : MonoBehaviour
{
    public List<Behaviour> enableList = new List<Behaviour>();
    public List<GameObject> disableList = new List<GameObject>();

    void Update()
    {
        if (GameManager.GM.hand1Tracked && GameManager.GM.hand2Tracked)
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
