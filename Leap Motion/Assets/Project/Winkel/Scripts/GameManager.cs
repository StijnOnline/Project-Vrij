using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int score = 0;

    [Header("Cart")]
    public GameObject cart;
    public GameObject cartCamera;
    public GameObject choiceDisplay;
    [HideInInspector] public GameObject currentChoice;

    [Header("Hands")]
    public Transform hands;
    public Transform hand1;
    public Transform hand2;
    public InteractionManager InteractionManager;
    public InteractionController hand1Controller;
    public InteractionController hand2Controller;
    [HideInInspector] public bool hand1Tracked = false;
    [HideInInspector] public bool hand2Tracked = false;

    [Header("Products")]
    public List<GameObject> allProducts = new List<GameObject>();
    public List<GameObject> shoppingList = new List<GameObject>();
    public List<string> shoppingListNames = new List<string>();
    public List<int> amounts = new List<int>();
    public List<GameObject> inCart = new List<GameObject>();
    public AudioSource productAudioSource;
    public AudioClip[] productSounds;
    public float shoppingListSize = 100;
    public Vector2Int minMaxAmounts;

    [Header("Pausing")]
    [HideInInspector] public bool paused = false;
    public float pauseDelay = 1f;
    private float lastTracked = 0f;
    public GameObject pauseScreen;
    public List<AudioSource> audioSources;

    [Header("Start")]
    public GameObject logo;
    public GameObject grabText;
    public GameObject groceryList;
    


    private void Start()
    {
        GM = this;
        DontDestroyOnLoad(gameObject);

        if (shoppingListSize > allProducts.Count) { shoppingListSize = allProducts.Count; }

        while (shoppingList.Count < shoppingListSize)
        {
            GameObject product = allProducts[Random.Range(0, allProducts.Count)];
            if (!shoppingList.Contains(product))
            {
                shoppingList.Add(product);
                shoppingListNames.Add(product.GetComponent<Product>().name);
                amounts.Add(Random.Range(minMaxAmounts.x, minMaxAmounts.y + 1));
            }

        }
    }

    private void Update()
    {
        hand1Tracked = hand1Controller.isTracked;
        hand2Tracked = hand2Controller.isTracked;
        if (!logo.activeSelf)
        {
            if (GameManager.GM.hand1Tracked && GameManager.GM.hand2Tracked)
            {
                lastTracked = Time.time;
                if (paused)
                {
                    paused = false;
                    pauseScreen.SetActive(false);
                    cart.GetComponent<Rigidbody>().isKinematic = false;
                    InteractionManager.enabled = true;
                    foreach (AudioSource AudioSrc in audioSources)
                    {
                        AudioSrc.Play();
                    }
                }
            }

            if (Time.time > lastTracked + pauseDelay)
            {
                paused = true;
                pauseScreen.SetActive(true);
                cart.GetComponent<Rigidbody>().isKinematic = true;
                InteractionManager.enabled = false;
                foreach (AudioSource AudioSrc in audioSources)
                {
                    AudioSrc.Pause();
                }
            }

            if (paused)
            {
                pauseScreen.transform.GetChild(0).gameObject.SetActive(hand1Tracked);
                pauseScreen.transform.GetChild(1).gameObject.SetActive(hand2Tracked);
            }
        }
        else if (GameManager.GM.hand1Tracked && GameManager.GM.hand2Tracked)
        {
            logo.SetActive(false);
        }
    }

    public void StartGame()
    {
        cart.GetComponent<CartMovement>().enabled = true;
        cartCamera.GetComponent<CameraLook>().panMultiplier = 100f;
        groceryList.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        grabText.SetActive(false);
    }

}
