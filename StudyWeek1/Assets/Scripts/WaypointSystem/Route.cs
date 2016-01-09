using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Route : MonoBehaviour {

    public List<GameObject> Waypoints = new List<GameObject>();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetNext(GameObject currentWaypoint)
    {
        if (Waypoints.IndexOf(currentWaypoint) >= Waypoints.Count)
        {
            return Waypoints[0];
        }
        else
        {
            return Waypoints[Waypoints.IndexOf(currentWaypoint) + 1];
        }
    }
}
