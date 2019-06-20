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
            Product product = other.GetComponent<Product>();
            productText.SetText(product.name + "\n ");
            StartCoroutine(Check(product.name, product.score));               
        }
    }

    public IEnumerator Check(string name, int score)
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.GM.shoppingListNames.Contains(name) && GameManager.GM.amounts[GameManager.GM.shoppingListNames.IndexOf(name)] > 0)
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
