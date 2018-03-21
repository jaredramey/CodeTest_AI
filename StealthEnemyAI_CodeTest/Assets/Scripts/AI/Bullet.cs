using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    public float lifeSpan = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
