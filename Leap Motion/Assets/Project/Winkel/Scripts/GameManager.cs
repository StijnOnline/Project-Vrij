using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    [Header("Cart")]
    public GameObject cart;
    public GameObject cartCamera;
    public GameObject choiceDisplay;
    [HideInInspector] public GameObject currentChoice;

    [Header("Hands")]
    public Transform hand1;
    public Transform hand2;
    public InteractionManager InteractionManager;
    public InteractionController hand1Controller;
    public InteractionController hand2Controller;
    [HideInInspector] public bool hand1Tracked = false;
    [HideInInspector] public bool hand2Tracked = false;

    [Header("Products")]
    public List<GameObject> allProducts = new List<GameObject>();
    public List<string> shoppingList = new List<string>();
    public List<int> amounts = new List<int>();
    public List<GameObject> inCart = new List<GameObject>();

    [Header("Pausing")]
    [HideInInspector] public bool paused = false;
    public float pauseDelay = 1f;
    private float lastTracked = 0f;
    public GameObject pauseScreen;
    public List<AudioSource> audioSources;

    [Header("Start")]
    public GameObject logo;
    


    private void Start()
    {
        GM = this;
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
        GameManager.GM.cart.GetComponent<CartMovement>().enabled = true;
        GameManager.GM.cartCamera.GetComponent<CameraLook>().panMultiplier = 100f;
        //fade title screen logo


    }

}
