using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] GameObject[] waypoints;
    int currentWaypointIdx = 0;

    [SerializeField] float speed = 1f;
    [SerializeField] float waypointSwitchThreshhold = 0.1f;


    GameObject getCurrentWaypoint()
    {
        return waypoints[currentWaypointIdx];
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length < 2)
        {
            throw new System.Exception("Must have at least 2 waypoints");
        }

        //move towards waypoint
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.getCurrentWaypoint().transform.position, speed * Time.deltaTime);

        //if we've reached a waypoint,
        if (Vector3.Distance(this.transform.position, this.getCurrentWaypoint().transform.position) <= waypointSwitchThreshhold)
        {
            //go to the next waypoint
            currentWaypointIdx += 1;
            //bounds checking
            if (currentWaypointIdx >= waypoints.Length)
            {
                currentWaypointIdx = 0;
            }
        }

    }
}
