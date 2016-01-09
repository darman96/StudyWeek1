using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour {

    public List<GameObject> Routes = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    Vector3 GetNextWaypoint(int route, GameObject currentWaypoint)
    {
        return Routes[route].GetComponent<Route>().GetNext(currentWaypoint).transform.position;
    }
}
