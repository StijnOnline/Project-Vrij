using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LopendeBand : MonoBehaviour
{
    public float speed = 0.1f;
    public float forceMultiplier = 2f;
    Vector2 offset = new Vector2();

    void Update()
    {
        offset += new Vector2(0, speed);
        Material mat = GetComponent<MeshRenderer>().material;
        mat.SetTextureOffset("_MainTex", offset);
        mat.SetTextureOffset("_DetailAlbedoMap", offset);
    }

    private void OnCollisionStay(Collision otherThing)
    {
        otherThing.rigidbody.velocity = new Vector3(0, 0, speed * forceMultiplier);
    }
}
