using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public string name;
    public int score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 3.5f)
        {
            GameManager.GM.productAudioSource.PlayOneShot(GameManager.GM.productSounds[Random.Range(0, GameManager.GM.productSounds.Length - 1)]);
        }
    }
}
