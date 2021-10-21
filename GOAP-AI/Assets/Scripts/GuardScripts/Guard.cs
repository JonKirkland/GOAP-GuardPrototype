using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public Transform pathHolder;
    public NavMeshAgent agent;
    public bool isPatrolling = true;
    void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
        }
        StartCoroutine(FollowPath(waypoints));
    }

    // Update is called once per frame
    void Update()
    {
        if(isPatrolling = true)
        {

        }
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        int waypointIndex = 1;
        Vector3 targetWaypoint = waypoints[waypointIndex];
        while (isPatrolling)
        {
            agent.SetDestination(targetWaypoint);
            if(agent.remainingDistance < 0.2f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[waypointIndex];
                //insert waittime here if needed
            }
            yield return null;
        }
    }

    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach(Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);
    }
}
