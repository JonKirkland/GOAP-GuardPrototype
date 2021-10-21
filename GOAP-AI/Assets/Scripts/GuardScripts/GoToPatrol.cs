using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPatrol : GAction
{
    private bool isPatrolling;
    public override bool PrePerform()
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
        }

        isPatrolling = true;
        print("running");
        //print("StartCoroutine");
        StartCoroutine(FollowPath(waypoints));
        return true;
    }
    public override bool PostPerform()
    {
        isPatrolling = false;
        print("DONE");
        return true;
    }
    IEnumerator FollowPath(Vector3[] waypoints)
    {
        print("StartCoroutine");
        //agent.autoBraking = false;
        runUntilElse = true;
        int waypointIndex = 0;
        Vector3 targetWaypoint = waypoints[waypointIndex];
        while (isPatrolling)
        {

            agent.SetDestination(targetWaypoint);

            yield return new WaitForSeconds(0.1f);
            if (agent.remainingDistance < 0.2f) //bug where this passes multiple times due to agent still being in vicinity so added wait above
            {
                
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                print(waypointIndex);
                targetWaypoint = waypoints[waypointIndex];
                if(targetWaypoint == waypoints[0])
                {
                    print("aklsdjnmalksd");
                    runUntilElse = false;
                    isPatrolling = false;
                }
                //insert waittime here if needed
            }
            
            
            yield return null;
        }
    }


}
