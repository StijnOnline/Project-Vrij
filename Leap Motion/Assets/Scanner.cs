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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Product")
        {
            productText.color = Color.black;
            AudioSource.PlayOneShot(bleep);
            string[] split = other.gameObject.name.Split('+');
            productText.SetText(split[0] + "\n ");
            StartCoroutine(Check(split[0], int.Parse(split[1].Split('(')[0])));               
        }
    }

    public IEnumerator Check(string name, int score)
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.GM.shoppingList.Contains(name) && GameManager.GM.amounts[GameManager.GM.shoppingList.IndexOf(name)] > 0)
        {
            productText.text += "+" + score;
            productText.color = Color.green;
            GameManager.GM.score += score;
        }
        else
        {
            productText.text += "-" + score;
            productText.color = Color.red;
            GameManager.GM.score -= score;
        }
        scoreText.SetText("Total: " + GameManager.GM.score);
    }
}
