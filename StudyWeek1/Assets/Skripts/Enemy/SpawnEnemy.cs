using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    //light enemy
    public GameObject m_enemyLight1;
    //medium enemy
    public GameObject m_enemyMedium1;

    //Spawnpoint
    public GameObject m_enemySpawnPoint;
    public GameObject m_enemySpawnLeftMax;
    public GameObject m_enemySpawnRightMax;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void Spawner(GameObject _enemy) {
        Instantiate(_enemy, new Vector3(Random.Range(m_enemySpawnLeftMax.transform.position.x, m_enemySpawnRightMax.transform.position.x), m_enemySpawnPoint.transform.position.y, m_enemySpawnPoint.transform.position.z), Quaternion.identity);
    }
}
