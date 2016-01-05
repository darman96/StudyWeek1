using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float Speed = 100f;
    public bool Explosive = false;

    public float lifetime = 3f;

    private Rigidbody rig;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        rig.AddForce(Vector3.forward * Speed, ForceMode.Impulse);
	}

    void Update()
    {
        if (rig.velocity == Vector3.zero) Destroy(gameObject);
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {

        //TODO: Hit detection and Damage
        //TODO: Particle Effect impact / explosion

        //Destroy(gameObject);
    }
}
