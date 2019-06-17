using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scanner : MonoBehaviour
{
    public TextMeshProUGUI productText;
    public TextMeshProUGUI scoreText;
    public AudioSource AudioSource;

    public AudioClip bleep;

    int totalScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Product")
        {
            AudioSource.PlayOneShot(bleep);
            productText.SetText(other.gameObject.name.Split('(')[0]);
            scoreText.SetText("Total: " + totalScore);
        }
    }

    public IEnumerator Check()
    {
        yield return 0;
    }
}
