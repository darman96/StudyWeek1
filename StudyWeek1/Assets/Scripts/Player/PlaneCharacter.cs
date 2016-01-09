using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlaneCharacter : MonoBehaviour {

    //Time between Shots & so
    public float m_TimeToNextShot = 0.1f;
    private bool m_NextShot = true;

    public float FlightLevel = 10f;

    public int ShieldDuration = 5;

    public int MaxHP = 5;
    public int CurrentHP = 5;
    public int Lives = 3;

    //Player Number
    public int m_PlayerNumber = 1;

    // Contains all projectiles for the Weapon Stages
    public List<GameObject> Projectiles = new List<GameObject>();
    public List<GameObject> WeaponMounts = new List<GameObject>();



    private int WeaponMod;

    private float CurrentShieldDuration  = 0;

    // Audio Variable
    private AudioSource audio;

    // Array for Health Sprites

	void Start ()
    {
        CurrentHP = MaxHP;

        audio = GetComponent<AudioSource>();    
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Keep Character on flight level
	    if(transform.position.y < FlightLevel || transform.position.y > FlightLevel)
        {
            Vector3 curPos = transform.position;
            curPos.y = FlightLevel;
            transform.position = curPos;
        }

        InputHandling();

    }

    private void InputHandling()
    {
        // Shooting
        if(Input.GetKey(KeyCode.Space) && m_NextShot == true && m_PlayerNumber == 1) {
            Attack();
            m_NextShot = false;
            //Hold the bullets back
            StartCoroutine(StopShotting(m_TimeToNextShot));
        }
        if(Input.GetKey(KeyCode.Keypad0) && m_NextShot == true && m_PlayerNumber == 2) {
            Attack();
            m_NextShot = false;
            //Hold the bullets back
            StartCoroutine(StopShotting(m_TimeToNextShot));
        }
    }

    IEnumerator StopShotting(float _TimeToWait) {
        yield return new WaitForSeconds(_TimeToWait);
        m_NextShot = true;
    }

    private void Attack()
    {
        // Instantiate projectile of the current weapon stage
        Instantiate(Projectiles[WeaponMod],transform.position , Quaternion.identity);
    }

    public void CollectPowerUp(int powerUp)
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

    public void calcHP (int dmg)
    {
        CurrentHP -= dmg;
        float hp = (float)CurrentHP / (float)MaxHP;

        if (CurrentHP <= 0)
        {
            Lives -= 1;
        }

        if(Lives <= 0)
        {
            Application.LoadLevel(Application.loadedLevelName);
        }

    }
}
