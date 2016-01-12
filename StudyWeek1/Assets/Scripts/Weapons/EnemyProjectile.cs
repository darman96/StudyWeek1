using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    public float m_Speed = 100f;
    public bool Explosive = false;

    public GameObject ParticleEffektHit;

    void Start()
    {
        transform.LookAt(GameObject.FindWithTag("Player").transform);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed, Space.Self);
    }

}
