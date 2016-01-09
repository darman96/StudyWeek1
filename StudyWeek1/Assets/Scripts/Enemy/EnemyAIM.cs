﻿using UnityEngine;
using System.Collections;

public class EnemyAIM : MonoBehaviour {

    //player
    private GameObject m_player1;
    private GameObject m_player2;
    //Ammo type (Bulet or Rocket)
    public GameObject m_ammonition;
    //Ammo Spawnpoint
    public GameObject m_ammoSpawn;
    //Spread
    public float m_spread = 10.0f;
    public float m_spreadMultiplyer = 50f;

    //Distances
    private Vector3 m_dist1;
    private Vector3 m_dist2;

    //Variablen
    private float m_ply1Dist = 0f;
    private float m_ply2Dist = 0f;
    private int m_playerCount = 1;  //Move to MasterScript

    //To modiy the initialized shots
    GameObject m_shot;

    // Use this for initialization
    void Start () {
        m_player1 = GameObject.FindGameObjectWithTag("Player1");
        m_player2 = GameObject.FindGameObjectWithTag("Player2");
        m_playerCount = GameObject.Find("Master-Indestructable").GetComponent<Master>().m_playerCount;
    }
	
	// Update is called once per frame
	void Update () {
        switch(m_playerCount) {
            case 1:
                ShootAtPlayer(m_player1);
                break;
            case 2:
                NearestPlayer();
                if(m_ply1Dist < m_ply2Dist) {
                    ShootAtPlayer(m_player1);
                    print("pl1");
                } else {
                    ShootAtPlayer(m_player2);
                    print("pl2");
                }
                break;
        }
	}

    void NearestPlayer() {
        //Distance to Player1
        m_dist1 = transform.position - m_player1.transform.position;
        m_ply1Dist = Vector3.SqrMagnitude(m_dist1);
        //Distance to Player2
        m_dist2 = transform.position - m_player2.transform.position;
        m_ply2Dist = Vector3.SqrMagnitude(m_dist2);
    }
    void ShootAtPlayer(GameObject _Player) {
        //Initialize the shot
        m_shot = (GameObject)Instantiate(m_ammonition, m_ammoSpawn.transform.position,
            //Rotate to the Player
            Quaternion.LookRotation(((_Player.transform.position - transform.position) 
            //Initialize the spread
            + new Vector3(Random.Range(-m_spread, m_spread), 0, Random.Range(-m_spread, m_spread) + 20))
            //Say where is upwards
            , Vector3.up));
        //Retag the initialized shot and set to the "EnemyShot" Layer
        m_shot.tag = "Enemy";
        m_shot.layer = 11;
    }
}
