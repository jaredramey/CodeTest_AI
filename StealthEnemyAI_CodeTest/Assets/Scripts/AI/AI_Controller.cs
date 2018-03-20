using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Chase))]
[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(NavMeshAgent))]
public class AI_Controller : MonoBehaviour
{
    private Chase chase;
    private Patrol patrol;
    private NavMeshAgent navMesh;
    bool Test_ForceCanSeePlayer;

    // Use this for initialization
    void Start()
    {
        chase = gameObject.GetComponent<Chase>();
        patrol = gameObject.GetComponent<Patrol>();
        navMesh = gameObject.GetComponent<NavMeshAgent>();

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
            //patrol.shouldPatrol = false;
            Test_MoveToPlayer();
        }
        else if (/*chase.shouldChase == false || */Test_ForceCanSeePlayer == false)
        {
            NavigateToNextPatrolPoint();
            //patrol.shouldPatrol = true;
        }
    }

    private void NavigateToNextPatrolPoint()
    {
        Debug.Log("Moving To patrol point");
        Vector3 targetDestination = patrol.GetNextPatrolPoint();
        navMesh.destination = targetDestination;
    }

    private void Test_MoveToPlayer()
    {
        Debug.Log("Moving To player");
        Vector3 targetDestination = GameObject.Find("Player").transform.position;
        navMesh.destination = targetDestination;
    }
}
