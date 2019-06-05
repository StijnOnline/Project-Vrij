using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartChoice : MonoBehaviour
{
    public GameObject choice;
    public List<string> choiceText;

    
    

    public List<Transform> left = new List<Transform>();
    public List<Transform> right = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {            
            choice.SetActive(true);
            choice.GetComponent<Choice>().startChoice = this;
            for (int i = 0; i< 3; i++)
            {
                Transform child = choice.transform.GetChild(i);
                TextMeshPro t = child.GetComponentInChildren<TextMeshPro>();
                t.SetText(choiceText[i]);
                
            }
        }
    }
}
