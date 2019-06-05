using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductTracker : MonoBehaviour
{
    public int shoppingListSize = 5;
    public Vector2Int minMaxAmounts;
    public TextMeshProUGUI listText;

    void Start()
    {
        if(shoppingListSize >GameManager.GM.allProducts.Count) { shoppingListSize = GameManager.GM.allProducts.Count; }

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
            listText.text += "- "+ GameManager.GM.amounts[i] + " " + GameManager.GM.shoppingList[i] + (GameManager.GM.amounts[i] > 1 ? "(s)" : "") + "\n";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Product") {
            GameManager.GM.inCart.Add(other.gameObject);
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
