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
    public AudioClip yay;
    public AudioClip boo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Product" )
        {
            productText.color = Color.black;
            AudioSource.PlayOneShot(bleep);
            Product product = other.GetComponent<Product>();
            productText.SetText(product.name + "\n ");
            StartCoroutine(Check(product.name, product.score));               
        }

        if (other.transform.parent != null && other.transform.parent.tag == "Product")
        {
            productText.color = Color.black;
            AudioSource.PlayOneShot(bleep);
            Product product = other.transform.parent.GetComponent<Product>();
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
            GameManager.GM.amounts[GameManager.GM.shoppingListNames.IndexOf(name)] -= 1;
            AudioSource.PlayOneShot(yay);
        }
        else
        {
            productText.text += "-" + score;
            productText.color = Color.red;
            GameManager.GM.score -= score;
            AudioSource.PlayOneShot(boo);
        }
        scoreText.SetText("Total: " + GameManager.GM.score);
    }

    public void MissingProducts()
    {
        int missingScore = 0;
        for(int i= 0; i < GameManager.GM.amounts.Count; i++)
        {
            missingScore += GameManager.GM.amounts[i] * GameManager.GM.shoppingList[i].GetComponent<Product>().score;

        }
        productText.text = "Missing Products\n-"+missingScore;
        productText.color = Color.red;
        GameManager.GM.score -= missingScore;
        scoreText.SetText("Total: " + GameManager.GM.score);
    }
}
