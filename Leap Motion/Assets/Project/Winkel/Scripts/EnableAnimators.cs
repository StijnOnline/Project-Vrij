using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimators : MonoBehaviour
{
    public Animator[] animatorsToEnable;
    public string requiredTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == requiredTag)
        {
            foreach(Animator animator in animatorsToEnable)
            {
                
                animator.SetTrigger("trigger"); 
            }
        }
    }
}
