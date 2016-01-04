﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaneCharacter : MonoBehaviour {

    public float MoveSpeed = 10f;
    public float FlightLevel = 10f;

    public int ShieldDuration = 5;

    public int MaxHP = 5;
    public int Lives = 3;

    // Contains all projectiles for the Weapon Stages
    public List<GameObject> Projectiles = new List<GameObject>();

    private int WeaponMod;
    private int CurrentHP;
    private float CurrentShieldDuration  = 0;

    private float xVelocity = 0;
    private float zVelocity = 0;

    private Rigidbody rig;
    private AudioSource audio;


	// Use this for initialization
	void Start ()
    {
        CurrentHP = MaxHP;

        rig = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Keep Character on flight level
	    if(transform.position.y < FlightLevel)
        {
            Vector3 curPos = transform.position;
            curPos.y = FlightLevel;
            transform.position = curPos;
        }

        InputHandling();

	}

    void FixedUpdate()
    {
        Movement();
    }

    void LateUpdate()
    {

    }

    private void InputHandling()
    {
        // Get velocity
        xVelocity = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        zVelocity = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        // Shooting
        if(Input.GetKey(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Movement()
    {
        // Tilt the plane when flying left or right
        if(xVelocity == 0)
        {
            transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
        if(xVelocity < 0)
        {
            transform.rotation = Quaternion.Euler(-90, 0, -45);
        }
        if(xVelocity > 0)
        {
            transform.rotation = Quaternion.Euler(-90, 0, 45);
        }

        transform.Translate(transform.TransformDirection(new Vector3(xVelocity, 0, zVelocity)));
    }

    private void Attack()
    {
        // Instantiate projectile of the current weapon stage
        Instantiate(Projectiles[WeaponMod],transform.position , transform.rotation);
    }

    private void CollectPowerUp(int powerUp)
    {

        switch(powerUp)
        {
            case 0:
                if (CurrentHP < MaxHP)
                    CurrentHP++;
                break;

            case 1:
                CurrentShieldDuration = ShieldDuration;
                break;

            case 2:
                WeaponMod++;
                break;
        }

    }

}
