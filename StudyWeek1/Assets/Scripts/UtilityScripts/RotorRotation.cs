using UnityEngine;
using System.Collections;

public class RotorRotation : MonoBehaviour {

    public float m_rotorSpeed = 55;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * m_rotorSpeed);
	}
}
