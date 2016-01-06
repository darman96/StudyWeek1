using UnityEngine;
using System.Collections;

public class RotateOcean : MonoBehaviour {

    public float rotationSpeed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
	}
}
