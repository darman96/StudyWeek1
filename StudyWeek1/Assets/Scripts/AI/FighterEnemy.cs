using UnityEngine;
using System.Collections;

public class FighterEnemy : Enemy {

    override protected void EnemyDeath()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameObject.Find("Master").GetComponent<Master>().RemoveFighter(gameObject);
    }
}
