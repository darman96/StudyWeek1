using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{

    public float Speed = 10f;
    public float RateOfFire = 0.2f;      // time in seconds per shot

    public int MaxHP = 10;

    public List<GameObject> Projectiles = new List<GameObject>();
    public List<GameObject> WeaponMounts = new List<GameObject>();

    private float FlightLevel;
    private float XMovement = 0;
    private float ZMovement = 0;
    private float LastFrameTime = 0;

    private int CurrentProjectileIndex = 0;
    private int CurrentHP = 0;

    private Master MasterComponent;

    // Use this for initialization
    void Start()
    {
        MasterComponent = GameObject.Find("Master").GetComponent<Master>();
        FlightLevel = MasterComponent.FlightLevel;

        LastFrameTime = Time.time;
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

        // reset flight level
        Vector3 currentPos = transform.position;
        currentPos.y = FlightLevel;
        transform.position = currentPos;

        InputHandling();
        Movement();

    }

    void InputHandling()
    {
        if (Input.GetButton("Fire1") && (Time.time - LastFrameTime >= RateOfFire))
        {
            Shoot();
            LastFrameTime = Time.time;
        }

        XMovement = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        ZMovement = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
    }

    void Movement()
    {
        transform.Translate(new Vector3(XMovement, 0, ZMovement));
    }

    // Instantiate a projectile for each WeaponMount
    void Shoot()
    {
        foreach (var weaponMount in WeaponMounts)
        {
            Instantiate(Projectiles[CurrentProjectileIndex], weaponMount.transform.position, transform.rotation);
        }
    }
}
