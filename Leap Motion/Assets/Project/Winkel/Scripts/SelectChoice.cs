using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChoice : MonoBehaviour
{
    public StartChoice.Choices choice;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.GM.currentChoice.GetComponent<StartChoice>().choice = choice;


        foreach (Renderer r in GameManager.GM.choiceDisplay.GetComponentsInChildren<Renderer>())
        {
            r.material.DisableKeyword("_EMISSION");
            r.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        }
        Material mat = GetComponent<Renderer>().material;
        mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        mat.EnableKeyword("_EMISSION");

    }
}
