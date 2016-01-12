using UnityEngine;
using System.Collections;

public class ModelRoundtable : MonoBehaviour {

    public float rotationSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAroundLocal(Vector3.up, rotationSpeed);
	}
}
