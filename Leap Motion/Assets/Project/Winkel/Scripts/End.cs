using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform spawnPoint;
    public float spawnDelay;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cart")
        {
            GameManager.GM.cart.GetComponent<Rigidbody>().isKinematic = true;
            GameManager.GM.cartCamera.GetComponent<CameraLook>().pan = false;
            StartCoroutine("PanCamera");
            StartCoroutine("Spawn");
        }
    }

    IEnumerator PanCamera()
    {
        while(GameManager.GM.cartCamera.transform.position != cameraTarget.position && GameManager.GM.cartCamera.transform.localRotation != cameraTarget.rotation)
        {
            GameManager.GM.cartCamera.transform.position = Vector3.Lerp(GameManager.GM.cartCamera.transform.position,cameraTarget.position,0.05f);
            GameManager.GM.cartCamera.transform.localRotation = Quaternion.Lerp(GameManager.GM.cartCamera.transform.rotation, cameraTarget.rotation, 0.05f);
            yield return null;
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < GameManager.GM.inCart.Count; i++)
        {
            GameManager.GM.inCart[i].SetActive(true);
            Instantiate(GameManager.GM.inCart[i], spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
