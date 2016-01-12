using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleEnemyAI : MonoBehaviour {

    public float Speed;
    public float RateOfFire = .5f;

    public GameObject Bullet;

    private float FlightLevel;
    private float LastFrameTime;

    private GameObject NextWaypoint;
    private Master MasterComp;

	// Use this for initialization
	void Start () {
        MasterComp = GameObject.Find("Master").GetComponent<Master>();
        FlightLevel = MasterComp.FlightLevel;

        Vector3 tempPos = transform.position;
        tempPos.y = FlightLevel;
        transform.position = tempPos;
    }

    // Update is called once per frame
    void Update() {
        
        if(Vector3.Distance(transform.position, NextWaypoint.transform.position) == 0)
        {
            NextWaypoint = NextWaypoint.GetComponent<Waypoint>().NextWaypoint;
        }

        Movement();
        
	}

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextWaypoint.transform.position, Speed * Time.deltaTime);
    }

    public void SetWaypoint(GameObject waypoint)
    {
        NextWaypoint = waypoint;
    }
}
