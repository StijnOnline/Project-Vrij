using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject cart;
    public GameObject cartCamera;
    [Space(5)]
    public Transform hand1;
    public Transform hand2;
    public InteractionController hand1Controller;
    public InteractionController hand2Controller;
    public bool hand1Tracked = false;
    public bool hand2Tracked = false;
    [Space(5)]

    public GameObject choiceDisplay;
    [HideInInspector] public GameObject currentChoice;

    [Space(5)]
    public List<GameObject> allProducts = new List<GameObject>();
    public List<string> shoppingList = new List<string>();
    public List<int> amounts = new List<int>();
    public List<GameObject> inCart = new List<GameObject>();

    [Space(5)]
    private float lastTracked = 0f;
    public bool paused = false;
    public float pauseDelay = 1f;
    public List<AudioSource> audioSources;

    private void Start()
    {
        GM = this;
    }

    private void Update()
    {
        hand1Tracked = hand1Controller.isTracked;
        hand2Tracked = hand2Controller.isTracked;

        if (GameManager.GM.hand1Tracked || GameManager.GM.hand2Tracked)
        {
            lastTracked = Time.time;
            if (paused)
            {
                paused = false;
                //Time.timeScale = 1;
                cart.GetComponent<Rigidbody>().isKinematic = false;
                foreach (AudioSource AS in audioSources)
                {
                    AS.Play();
                }
            }
        }

        if (Time.time > lastTracked + pauseDelay)
        {
            paused = true;
            //Time.timeScale = 0;
            cart.GetComponent<Rigidbody>().isKinematic = true;
            foreach (AudioSource AS in audioSources)
            {
                AS.Pause();
            }
        }
    }

}
