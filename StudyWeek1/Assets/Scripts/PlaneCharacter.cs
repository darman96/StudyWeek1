using UnityEngine;
using System.Collections;

public class PlaneCharacter : MonoBehaviour {

    public float MoveSpeed = 10f;
    public float FlightLevel = 10f;

    public int ShieldDuration = 5;

    public int MaxHP = 5;
    public int Lives = 3;

    private int WeaponMod;
    private int CurrentHP;
    private float CurrentShieldDuration  = 0;


	// Use this for initialization
	void Start ()
    {
        CurrentHP = MaxHP;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FixedUpdate()
    {

    }

    void LateUpdate()
    {

    }

    private void InputHandling()
    {

    }

    private void Movement()
    {

    }

    private void Attack()
    {

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
