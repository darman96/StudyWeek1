using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int MaxHP = 2;
    public int enemyPoints = 100;

    public GameObject explosion;

    public int CurrentHP;



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

    protected virtual void EnemyDeath() { }
}
