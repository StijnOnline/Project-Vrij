using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingNode : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {
            //disable objects in cart (save)
            foreach (GameObject g in GameManager.GM.inCart)
            {
                g.SetActive(false);
            }
            GameManager.GM.savedText.SetActive(true);
            StartCoroutine("DisableSavedText");
        }
    }

    IEnumerator DisableSavedText()
    {
        yield return new WaitForSeconds(1f);
        GameManager.GM.savedText.SetActive(false);
    }
}
