using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject cart;
    public GameObject cartCamera;
    [Space(10)]
    public Transform hand1;
    public Transform hand2;
    [Space(10)]

    public GameObject choiceDisplay;
    [HideInInspector] public GameObject currentChoice;

    [Space(10)]
    public List<GameObject> allProducts = new List<GameObject>();
    public List<string> shoppingList = new List<string>();
    public List<int> amounts = new List<int>();
    public List<GameObject> inCart = new List<GameObject>();

    private void Start()
    {
        GM = this;
    }

}
