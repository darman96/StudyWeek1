﻿using UnityEngine;
using System.Collections;

public class EnemyAIM : MonoBehaviour {

    //player
    private GameObject player1;
    private GameObject player2;
    //Ammo type (Bulet or Rocket)
    public GameObject ammonition;
    //Ammo Spawnpoint
    public GameObject ammoSpawn;
    //Spread
    public float spread = 10.0f;
    public float spreadMultiplyer = 50f;

    //Distances
    private Vector3 dist1;
    private Vector3 dist2;

    //Variablen
    private float ply1Dist = 0f;
    private float ply2Dist = 0f;
    private int playerCount = 1;  //Move to MasterScript

    //To modiy the initialized shots
    GameObject shot;

    // Use this for initialization
    void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        playerCount = GameObject.Find("Master-Indestructable").GetComponent<Master>().m_playerCount;
    }
	
	// Update is called once per frame
	void Update () {
        switch(playerCount) {
            case 1:
                ShootAtPlayer(player1);
                break;
            case 2:
                NearestPlayer();
                if(ply1Dist < ply2Dist) {
                    ShootAtPlayer(player1);
                    print("pl1");
                } else {
                    ShootAtPlayer(player2);
                    print("pl2");
                }
                break;
        }
	}

    void NearestPlayer() {
        //Distance to Player1
        dist1 = transform.position - player1.transform.position;
        ply1Dist = Vector3.SqrMagnitude(dist1);
        //Distance to Player2
        dist2 = transform.position - player2.transform.position;
        ply2Dist = Vector3.SqrMagnitude(dist2);
    }
    void ShootAtPlayer(GameObject _Player) {
        //Initialize the shot
        shot = (GameObject)Instantiate(ammonition, ammoSpawn.transform.position,
            //Rotate to the Player
            Quaternion.LookRotation(((_Player.transform.position - transform.position) 
            //Initialize the spread
            + new Vector3(Random.Range(-spread, spread), 0, Random.Range(-spread, spread) + ammoSpawn.transform.position.z))
            //Say where is upwards
            , Vector3.up));
        //Retag the initialized shot and set to the "EnemyShot" Layer
        shot.tag = "Enemy";
        shot.layer = 11;
    }
}
