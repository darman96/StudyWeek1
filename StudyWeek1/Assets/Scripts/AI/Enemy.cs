using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int MaxHP = 2;
    public int enemyPoints = 100;

    public GameObject explosion;

    private int CurrentHP;

	void Start ()
    {
        CurrentHP = MaxHP;
	}

    public void ApplyDamage(int damage)
    {
        CurrentHP -= damage;

        if(CurrentHP <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Find("Master").GetComponent<Master>().RemoveFighter(gameObject);

        Destroy(gameObject);
    }
}
