using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleEnemyAI : MonoBehaviour {

    public float Speed;
    public float RateOfFire = .5f;

    public GameObject Bullet;

    private float FlightLevel;
    private float LastFrameTime;

    private Rigidbody Rig;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        
        
	}

    private void Movement()
    {
        //transform.position = Vector3.MoveTowards(transform.position, CurrentDestination.position, Speed);
    }

}
