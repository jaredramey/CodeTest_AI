using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [HideInInspector]
    private List<Vector3> patrolPoints = new List<Vector3>();
    public bool shouldPatrol;
    public float speed;
    public bool showPath;
    private int index;

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

        if (!Application.isPlaying) return;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(shouldPatrol && patrolPoints.Count > 0)
        {
            Vector3 direction = patrolPoints[index] - gameObject.transform.position;
            gameObject.transform.position += (direction.normalized) * Time.deltaTime * speed;
            gameObject.transform.LookAt(patrolPoints[index]);

            if(direction.magnitude <= 1.0f)
            {
                index++;
                if(index >= patrolPoints.Count)
                {
                    index = 0;
                }
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
