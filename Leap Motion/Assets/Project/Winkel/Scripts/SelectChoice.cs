using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChoice : MonoBehaviour
{
    public StartChoice.Choices choice;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.GM.currentChoice.GetComponent<StartChoice>().choice = choice;
    }
}
