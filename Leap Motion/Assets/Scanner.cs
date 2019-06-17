using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scanner : MonoBehaviour
{
    public TextMeshProUGUI productText;
    public TextMeshProUGUI scoreText;
    public int totalScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Product")
        {
            productText.SetText(other.gameObject.name);
            scoreText.SetText("Total: " + totalScore);
        }
    }
}
