using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int maxEnemyHealth = 2;
    public int enemyPoints = 100;
         
    private int curEnemyHealth = 2;

	void Start ()
    {
	
	}
	

    public void calcHP(int iDmg)
    {
        curEnemyHealth -= iDmg;
        float eHP = (float)curEnemyHealth / (float)maxEnemyHealth;

        if (curEnemyHealth < 1)
        {
            EnemyDeath();
        }
    }
   void EnemyDeath()
    {
        PlaneCharacter plch = GameObject.Find("PlaneCharacter").GetComponent<PlaneCharacter> ();

        plch.calcPTS(enemyPoints);
        Destroy(gameObject);

    }
}
