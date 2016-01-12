using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int enemyPoints = 50;
    public int maxEnemyHealth = 2;
    private int curEnemyHealth = 2;

    public void calcHP(int iDmg)
    {
        curEnemyHealth -= iDmg;

        if (curEnemyHealth < 1)
        {
            EnemyDeath();
        }
    }
   void EnemyDeath()
    {
        //PlaneCharacter plch = GameObject.Find("PlaneCharacter").GetComponent<PlaneCharacter>();

        Destroy(gameObject);

    }
}
