using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Simple AI with dynamic Waypoints
/// </summary>
public class SimpleEnemyAI : MonoBehaviour {

    public List<GameObject> Waypoints = new List<GameObject>();

    private NavMeshAgent navAgent;
    private Transform currentWaypoint;
    private int currentWaypointIndex = 0;
    private NavMeshPath path;

	// Use this for initialization
	void Start () {
        // Get NavAgent component and set the first waypoint
        navAgent = GetComponent<NavMeshAgent>();
        currentWaypoint = Waypoints[currentWaypointIndex].transform;

        // Calculate and set the path for the first waypoint
        path = new NavMeshPath();
        navAgent.CalculatePath(currentWaypoint.position, path);
        navAgent.SetPath(path);
	}

    // Update is called once per frame
    void Update() {
        // precalculate the next path when distance to current waypoint < 1
        if (navAgent.remainingDistance < 1) {
            if (currentWaypointIndex < Waypoints.Count - 1) currentWaypointIndex++;
            else currentWaypointIndex = 0;

            currentWaypoint = Waypoints[currentWaypointIndex].transform;
            navAgent.CalculatePath(currentWaypoint.position, path);
        }

        // if waypoint is reached and path calculation finished, set the new path
        if(path.status == NavMeshPathStatus.PathComplete && navAgent.remainingDistance == 0)
        {
            navAgent.SetPath(path);
        }
	}
}
