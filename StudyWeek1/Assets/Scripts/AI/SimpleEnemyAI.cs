using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleEnemyAI : MonoBehaviour {

    public List<GameObject> Waypoints = new List<GameObject>();

    private NavMeshAgent navAgent;
    private Transform currentWaypoint;
    private int currentWaypointIndex = 0;
    private NavMeshPath path;

	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        currentWaypoint = Waypoints[currentWaypointIndex].transform;

        path = new NavMeshPath();
        navAgent.CalculatePath(currentWaypoint.position, path);
        navAgent.SetPath(path);
	}

    // Update is called once per frame
    void Update() {
        if (navAgent.remainingDistance < 1) {
            if (currentWaypointIndex < Waypoints.Count - 1) currentWaypointIndex++;
            else currentWaypointIndex = 0;

            currentWaypoint = Waypoints[currentWaypointIndex].transform;
            navAgent.CalculatePath(currentWaypoint.position, path);
        }
        if(path.status == NavMeshPathStatus.PathComplete && navAgent.remainingDistance == 0)
        {
            navAgent.SetPath(path);
            //navAgent.
        }
	}
}
