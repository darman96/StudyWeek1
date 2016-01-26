using UnityEngine;
using System.Collections;

public class Flugzeugträger : MonoBehaviour {

    public GameObject waypoint;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, 10 * Time.deltaTime);
	}
}
