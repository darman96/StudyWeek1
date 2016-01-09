using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float m_Speed = 100f;
    public bool Explosive = false;

    public GameObject ParticleEffektHit;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed, Space.Self);
    }

    void OnCollisionEnter(Collision col)
    {
        Instantiate(ParticleEffektHit, transform.position, Quaternion.identity);
    }
}
