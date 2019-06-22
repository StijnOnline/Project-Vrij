using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    public bool inCart = true;
    float lastTime = 0f;
    public float delay = 2f;
    [Space(5)]
    public Transform targetPos;
    public float showTime = 5f;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if (!GameManager.GM.playing)
        {
            if (inCart)
            {
                lastTime = Time.time;
            }
            if (Time.time > lastTime + delay) { Respawn(); }
        }        
    }


    void Respawn()
    {
        transform.localPosition = startPos;
    }

    public void StartShow()
    {
        GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        transform.SetParent(targetPos);
        StartCoroutine("Show");
    }

    IEnumerator Show()
    {
        while (transform.localPosition.magnitude > .1f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 0.1f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, 0.1f);
            yield return 0;
        }
        yield return new WaitForSeconds(showTime);
        while (transform.localPosition.magnitude < 1f)
        {
            transform.localPosition -= -Vector3.forward * 0.05f;
            yield return 0;
        }
        Destroy(gameObject);
    }
}
