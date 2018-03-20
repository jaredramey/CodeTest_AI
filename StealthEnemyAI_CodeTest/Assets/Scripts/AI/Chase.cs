using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent))]
public class Chase : MonoBehaviour
{
    public bool shouldChase;
    public float speed;
    private SphereCollider perception;
    private bool playerIsNear;
    private GameObject player;
    private NavMeshAgent navAgent;

    // Use this for initialization
    void Start()
    {
        shouldChase = false;
        playerIsNear = false;
        perception = gameObject.GetComponent<SphereCollider>();
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit canSeePlayer;

        if(playerIsNear)
        {
            Physics.Linecast(gameObject.transform.position, player.transform.position, out canSeePlayer);

            if(canSeePlayer.collider.gameObject == player)
            {
                shouldChase = true;
                ChasePlayer();
            }
            else
            {
                shouldChase = false;
            }
        }
    }

    private void ChasePlayer()
    {
        navAgent.destination = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerIsNear = false;
        }
    }
}
