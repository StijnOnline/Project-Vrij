using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductTracker : MonoBehaviour
{
    public List<GameObject> allProducts = new List<GameObject>();
    public List<string> shoppingList = new List<string>();
    public List<int> amounts = new List<int>();
    public List<GameObject> inCart = new List<GameObject>();


    public int shoppingListSize = 5;
    public Vector2Int minMaxAmounts;
    public TextMeshProUGUI listText;

    void Start()
    {
        if(shoppingListSize > allProducts.Count) { shoppingListSize = allProducts.Count; }

        while (shoppingList.Count < shoppingListSize)
        {
            string product = allProducts[Random.Range(0, allProducts.Count)].name;
            if (!shoppingList.Contains(product))
            {
                shoppingList.Add(product);
                amounts.Add(Random.Range(minMaxAmounts.x, minMaxAmounts.y + 1));
            }
            
        }

        for (int i = 0;i<shoppingList.Count;i++)
        {
            listText.text += "- "+ amounts[i] + " " + shoppingList[i] + (amounts[i] > 1 ? "s" : "") + "\n";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Product") {
            inCart.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Product")
        {
            inCart.Remove(other.gameObject);
        }
    }
}
