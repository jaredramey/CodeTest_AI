using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent))]
public class Chase : MonoBehaviour
{
    public bool shouldChase;
    private SphereCollider perception;
    private bool playerIsNear;
    private GameObject player;
    private NavMeshAgent navAgent;
    private Vector3 lastKnownPosition;

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

        if(playerIsNear == true)
        {
            Physics.Linecast(gameObject.transform.position, player.transform.position, out canSeePlayer);

            if(canSeePlayer.collider.gameObject.name == player.name)
            {
                shouldChase = true;
                ChasePlayer();
            }
            else
            {
                shouldChase = false;
            }
        }
        else
        {
            if (shouldChase == true)
            {
                shouldChase = false;
            }
        }
    }

    private void ChasePlayer()
    {
        if (navAgent.destination != player.transform.position && navAgent.remainingDistance >= 10)
        {
            navAgent.destination = player.transform.position;
        }
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
