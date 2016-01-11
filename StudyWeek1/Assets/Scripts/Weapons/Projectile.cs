using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float m_Speed = 100f;
    public bool Explosive = false;
    Rigidbody rig;

    void Start() {
        rig = GetComponent<Rigidbody>();
    }

    public GameObject ParticleEffektHit;

    void Update()
    {
        //The Simple way
        //transform.Translate(Vector3.forward * Time.deltaTime * m_Speed, Space.Self);

        //Better Collision detection
        rig.velocity = transform.forward * m_Speed;
    }

    void OnCollisionEnter(Collision col) {
        if((col.transform.tag == "Player1" || col.transform.tag == "Player2") && (transform.tag != "PlayerShot")) {
            Destroy(gameObject);
        }
        if(col.transform.tag == "Enemy" && transform.tag != "Enemy") {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Instantiate(ParticleEffektHit, transform.position, Quaternion.identity);
    }
}
