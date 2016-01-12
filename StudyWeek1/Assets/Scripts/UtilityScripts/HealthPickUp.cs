using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour
{
    public int healthValue = 1;
    public int destroyPickupAfterXSeconds = 0;
    public float rotationSpeed = 100f;

	// Use this for initialization
	void Start ()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void OnTriggerEnter ()
    {
        PlaneCharacter ply = GameObject.Find("Lockheed-Player1").GetComponent<PlaneCharacter>();
        ply.calcHP(healthValue);
       // Destroy(gameObject, destroyPickupAfterXSeconds);
	}
}
