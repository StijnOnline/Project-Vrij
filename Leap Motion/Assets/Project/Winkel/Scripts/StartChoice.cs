using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartChoice : MonoBehaviour
{
    public GameObject choice;
    public List<string> choiceText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {            
            choice.SetActive(true);
            for (int i = 0; i< 3; i++)
            {
                TextMeshProUGUI t = choice.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                t.text = choiceText[i];
            }
        }
    }
}
