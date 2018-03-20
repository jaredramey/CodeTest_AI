using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    private float speed = 0.0f;


    public void ShootAtTarget(GameObject target)
    {
        Vector3 initForce = (gameObject.transform.position += gameObject.transform.forward) * speed;
        GameObject shot = (GameObject)Instantiate(projectile, gameObject.transform);
        shot.GetComponent<Rigidbody>().AddForce(initForce);
    }
}
