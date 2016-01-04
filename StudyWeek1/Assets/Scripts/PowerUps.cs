using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{
    public int destroyPickupAfterXSeconds = 0;
    public float rotationSpeed = 100f;

    public int buffType = 0;

	// Use this for initialization
	void FixedUpdate ()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col)
    {
	if (col.gameObject.tag == "Player")
        {
//            col.GetComponent<PlaneCharacter>().CollectPowerUp(buffType);
        }

        Destroy(gameObject, destroyPickupAfterXSeconds);
	}
}
