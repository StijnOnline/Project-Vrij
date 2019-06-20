using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductTracker : MonoBehaviour
{
    public int shoppingListSize = 5;
    public Vector2Int minMaxAmounts;
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    public AudioSource audioSource;
    public AudioClip[] inCartSounds;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (shoppingListSize >GameManager.GM.allProducts.Count) { shoppingListSize = GameManager.GM.allProducts.Count; }

        while (GameManager.GM.shoppingList.Count < shoppingListSize)
        {
            string product = GameManager.GM.allProducts[Random.Range(0, GameManager.GM.allProducts.Count)].name;
            if (!GameManager.GM.shoppingList.Contains(product))
            {
                GameManager.GM.shoppingList.Add(product);
                GameManager.GM.amounts.Add(Random.Range(minMaxAmounts.x, minMaxAmounts.y + 1));
            }
            
        }

        for (int i = 0;i< GameManager.GM.shoppingList.Count;i++)
        {
            amountText.text += GameManager.GM.amounts[i] + "\n";
            nameText.text += GameManager.GM.shoppingList[i].Split('+')[0] + "\n";
            scoreText.text += GameManager.GM.shoppingList[i].Split('+')[1] + "\n";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Product") {
            GameManager.GM.inCart.Add(other.gameObject);
            audioSource.PlayOneShot(inCartSounds[Random.Range(0, inCartSounds.Length)]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Product")
        {
            GameManager.GM.inCart.Remove(other.gameObject);
        }
    }
}
