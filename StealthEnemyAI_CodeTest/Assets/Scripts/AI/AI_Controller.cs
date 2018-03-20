using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Chase))]
[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Shoot))]
public class AI_Controller : MonoBehaviour
{
    private Chase chase;
    private Patrol patrol;
    private Shoot shoot;
    private NavMeshAgent navAgent;
    bool Test_ForceCanSeePlayer;

    // Use this for initialization
    void Start()
    {
        chase = gameObject.GetComponent<Chase>();
        patrol = gameObject.GetComponent<Patrol>();
        shoot = gameObject.GetComponent<Shoot>();
        navAgent = gameObject.GetComponent<NavMeshAgent>();

        chase.shouldChase = false;
        patrol.shouldPatrol = false;
        Test_ForceCanSeePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Test_ForceCanSeePlayer == false)
            { Test_ForceCanSeePlayer = true; }
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            if (Test_ForceCanSeePlayer == true)
            { Test_ForceCanSeePlayer = false; }
        }

        if(/*chase.shouldChase == true || */Test_ForceCanSeePlayer == true)
        {
            patrol.shouldPatrol = false;
            Test_MoveToPlayer();
            shoot.ShootAtTarget(GameObject.Find("Player"));
        }
        else if (/*chase.shouldChase == false || */Test_ForceCanSeePlayer == false)
        {
            //NavigateToNextPatrolPoint();
            patrol.shouldPatrol = true;
        }
    }

    private void NavigateToNextPatrolPoint()
    {
        Debug.Log("Moving To patrol point");
        Vector3 targetDestination = patrol.GetNextPatrolPoint();
        navAgent.destination = targetDestination;
    }

    private void Test_MoveToPlayer()
    {
        Debug.Log("Moving To player");
        Vector3 targetDestination = GameObject.Find("Player").transform.position;
        navAgent.destination = targetDestination;
    }
}
