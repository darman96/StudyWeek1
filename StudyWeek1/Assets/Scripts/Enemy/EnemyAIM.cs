using UnityEngine;
using System.Collections;

public class EnemyAIM : MonoBehaviour {

    //player
    public GameObject m_player1;
    public GameObject m_player2;
    //Ammo type (Bulet or Rocket)
    public GameObject m_ammonition;
    //Ammo Spawnpoint
    public GameObject m_ammoSpawn;
    //Spread
    public float m_spread = 10.0f;

    //Distances
    private Vector3 m_dist1;
    private Vector3 m_dist2;

    //Variablen
    private float m_ply1Dist = 0f;
    private float m_ply2Dist = 0f;
    private int m_playerCount = 1;  //Move to MasterScript

    // Use this for initialization
    void Start () {
        m_player1 = GameObject.FindGameObjectWithTag("Player1");
        m_player2 = GameObject.FindGameObjectWithTag("Player2");
    }
	
	// Update is called once per frame
	void Update () {
        switch(m_playerCount) {
            case 1:
                ShotAtPlayer(m_player1);
                break;
            case 2:
                NearestPlayer();
                if(m_ply1Dist < m_ply2Dist) {
                    ShotAtPlayer(m_player1);
                } else {
                    ShotAtPlayer(m_player2);
                }
                break;
        }
	}

    void NearestPlayer() {
        //Distance to Player1
        m_dist1 = m_player1.transform.position - transform.position;
        m_ply1Dist = Vector3.SqrMagnitude(m_dist1);
        //Distance to Player2
        m_dist2 = m_player2.transform.position - transform.position;
        m_ply2Dist = Vector3.SqrMagnitude(m_dist2);
    }
    void ShotAtPlayer(GameObject _Player) {
        Instantiate(m_ammonition, m_ammoSpawn.transform.position, Quaternion.LookRotation((_Player.transform.position + new Vector3(Random.Range(-m_spread, m_spread), 0, 0)), Vector3.up));
    }
}
