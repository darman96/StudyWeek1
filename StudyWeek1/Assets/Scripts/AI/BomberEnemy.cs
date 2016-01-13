using UnityEngine;
using System.Collections;

public class BomberEnemy : Enemy {

    override protected void EnemyDeath()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameObject.Find("Master").GetComponent<Master>().RemoveBomber(gameObject);
    }

}
