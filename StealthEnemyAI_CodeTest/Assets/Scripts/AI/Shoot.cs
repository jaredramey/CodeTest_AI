using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float spawnForward = 0;
    private float speed = 0.0f;

    public void ShootAtTarget()
    {
        Vector3 initForce = (gameObject.transform.position += gameObject.transform.forward) * speed;
        float spawnX = gameObject.transform.position.x + (gameObject.transform.forward.x * spawnForward);
        float spawnY = gameObject.transform.position.y;
        float spawnZ = gameObject.transform.position.z + (gameObject.transform.forward.z * spawnForward);
        Vector3 spawnLoc = new Vector3(spawnX, spawnY, spawnZ);
        //GameObject shot = (GameObject)Instantiate(projectile, spawnLoc, Quaternion.identity);
        //shot.GetComponent<Rigidbody>().AddForce(initForce);
    }
}
