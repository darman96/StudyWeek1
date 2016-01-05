using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float Speed = 100f;
    public bool Explosive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision col)
    {

        //TODO: Hit detection and Damage
        //TODO: Particle Effect impact / explosion

        Destroy(gameObject);
    }
}
