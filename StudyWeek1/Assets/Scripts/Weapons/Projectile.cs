using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float Speed = 100f;

    public int Damage = 1;

    public bool Explosive = false;

    private Rigidbody rig;

    public GameObject ParticleEffektHit;

    void Start() {
        rig = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //The Simple way
        //transform.Translate(Vector3.forward * Time.deltaTime * m_Speed, Space.Self);

        //Better Collision detection
        rig.velocity = transform.forward * Speed;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Bullet Collision");

        if(col.transform.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().ApplyDamage(Damage);
            Destroy(gameObject);
        }

    }

}
