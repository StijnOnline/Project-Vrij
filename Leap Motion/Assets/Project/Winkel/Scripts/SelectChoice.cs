using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChoice : MonoBehaviour
{
    public Choice.Choices choice;
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<Choice>().choice = choice;
    }
}
