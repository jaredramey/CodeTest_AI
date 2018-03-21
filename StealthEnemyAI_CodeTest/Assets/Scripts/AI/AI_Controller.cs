using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Chase))]
[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(NavMeshAgent))]
public class AI_Controller : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Chase chase;
    private Patrol patrol;
    private Shoot shoot;
    private float timer = 0.5f;
    private NavMeshAgent navAgent;
    bool Test_ForceCanSeePlayer;

    // Use this for initialization
    void Start()
    {
        chase = gameObject.GetComponent<Chase>();
        patrol = gameObject.GetComponent<Patrol>();
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        bulletSpawn = gameObject.transform.Find("BulletSpawn");

        chase.shouldChase = false;
        patrol.shouldPatrol = false;
        Test_ForceCanSeePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(chase.shouldChase == true)
        {
            patrol.shouldPatrol = false;
            Shoot();
        }
        else if (chase.shouldChase == false)
        {
            patrol.shouldPatrol = true;
        }
    }

    private void Shoot()
    {
        timer -= Time.deltaTime;

        gameObject.transform.LookAt(GameObject.Find("Player").transform);

        if (timer <= 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

            Destroy(bullet, 8.0f);

            timer = 0.5f;
        }
    }

    private void OnGUI()
    {
        if(chase.shouldChase == true)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width, Screen.height), "Shooting at the player!");
        }
    }
}
