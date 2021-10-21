using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.AI;

public class GuardVision : MonoBehaviour
{


    Transform player;

    public Light spotlight;
    public float viewDistance;
    private float viewAngle;
    public LayerMask guardViewMask;

    Color originalSpotlightColor;


    void Start()
    {
        originalSpotlightColor = spotlight.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        
    }

    public bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            //angle between guard forward direction and direction to player are within view angle
            Vector3 dirToPlayer = (player.position - transform.position).normalized; //unit vect
            float angleToPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if(angleToPlayer < (viewAngle / 2))
            {
                //check line of sight
                if (!Physics.Linecast(transform.position, player.position, guardViewMask)) //if havent hit an obstacle
                    return true;

            }
        }
        return false;
    }
    void Update()
    {

        if (CanSeePlayer())
        {
            spotlight.color = Color.red;
        }
        /*
        else
        {
            spotlight.color = originalSpotlightColor;
        }
        */
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
