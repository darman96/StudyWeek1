using UnityEngine;
using System.Collections;

public class ModelRoundtable : MonoBehaviour {

    public float rotationSpeed = 0.5f;

	// Update is called once per frame
	void Update () {
        transform.RotateAroundLocal(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
