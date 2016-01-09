using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleEnemyAI : MonoBehaviour {

    public float Speed;

    private float FlightLevel;

    private Transform CurrentDestination;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");

        CurrentDestination = player.transform;
	}

    // Update is called once per frame
    void Update() {
        
        if(DistanceToDestination() == 0)
        {
            if(DistanceToPlayer() <= 15)
            {
                SetRandomWaypoint();
            } else
            {
                CurrentDestination = player.transform;
            }
        }

        Movement();
        
	}

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentDestination.position, Speed);
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    private float DistanceToDestination()
    {
        return Vector3.Distance(transform.position, CurrentDestination.position);
    }

    private void SetRandomWaypoint()
    {
        List<GameObject> waypoints = new List<GameObject>();
        waypoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));

        CurrentDestination = waypoints[Random.Range(0, waypoints.Count - 1)].transform;
    }


}
