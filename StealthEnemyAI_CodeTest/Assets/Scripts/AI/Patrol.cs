using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Patrol : MonoBehaviour
{
    [HideInInspector]
    private List<Vector3> patrolPoints = new List<Vector3>();
    public bool shouldPatrol;
    public bool showPath;
    private int index;
    private NavMeshAgent navAgent;

    // Use this for initialization
    void Start()
    {
        foreach(Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.name == "pathNode")
            {
                patrolPoints.Add(t.position);
            }
        }

        navAgent = gameObject.GetComponent<NavMeshAgent>();
        index = 0;
        navAgent.destination = patrolPoints[index];
    }

    // Update is called once per frame
    void Update()
    {

        if(shouldPatrol && patrolPoints.Count > 0)
        {
            if(navAgent.remainingDistance <= 1.0f)
            {
                index++;
                if (index >= patrolPoints.Count)
                {
                    index = 0;
                }
                navAgent.destination = patrolPoints[index];
            }
        }
    }

    public Vector3 GetNextPatrolPoint()
    {
        return patrolPoints[index];
    }

    private void OnDrawGizmos()
    {
        if(showPath)
        {
            foreach(Transform t in GetComponentsInChildren<Transform>())
            {
                if(t.name == "pathNode")
                {
                    Gizmos.DrawWireSphere(t.position, 0.2f);
                }
            }
        }
    }

    public GameObject AddNode()
    {
        GameObject newNode = new GameObject();
        newNode.transform.SetParent(gameObject.transform);
        newNode.transform.position = gameObject.transform.position;
        newNode.name = "pathNode";
        return newNode;
    }
}
