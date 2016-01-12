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
        //For Players
        if(gameObject.tag == "PlayerShot") {
            rig.velocity = transform.forward * m_Speed;
        }
        //For Enemys
        if(gameObject.layer == 11) {
            rig.velocity = transform.forward * (m_Speed / 2);
        }
    }

    void OnCollisionEnter(Collision col) {
        if((col.transform.tag == "Player1" || col.transform.tag == "Player2") && (transform.tag != "PlayerShot")) {
            //Instantiate(ParticleEffektHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(col.transform.tag == "Enemy" && transform.tag != "Enemy") {
            //Instantiate(ParticleEffektHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
