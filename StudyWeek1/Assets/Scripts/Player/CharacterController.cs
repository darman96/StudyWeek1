using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{

    public float Speed = 10f;
    public float TiltSpeed = 0;
    public float RateOfFire = 0.2f;      // time in seconds per shot

    public int MaxHP = 10;

    public GameObject GatlingProjectile;
    public GameObject GatlingMount;
    public GameObject explosion;

    public GameObject MissileProjectile;
    public List<GameObject> MissileMounts = new List<GameObject>();

    private float FlightLevel;
    private float XMovement = 0;
    private float ZMovement = 0;
    private float LastFrameTime = 0;

    public int CurrentHP = 0;

    private Master master;

    // Use this for initialization
    void Start()
    {
        master = GameObject.Find("Master").GetComponent<Master>();
        FlightLevel = master.FlightLevel;

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

    private void InputHandling()
    {
        if (Input.GetKey(KeyCode.Space) && (Time.time - LastFrameTime >= RateOfFire))
        {
            Shoot();
            LastFrameTime = Time.time;
        }

        XMovement = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        ZMovement = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
    }

    private void Movement()
    {
        transform.Translate(new Vector3(XMovement, 0, ZMovement));

        Rotate(XMovement, ZMovement);
    }

    private void Rotate(float xVeloc, float zVeloc)
    {
        //Left drill
        if (xVeloc < 0 && (transform.rotation.z < 20 || transform.rotation.z >= 340))
        {
            transform.Rotate(Vector3.forward, TiltSpeed * Time.deltaTime);
        }
        if (transform.rotation.eulerAngles.z > 20 && transform.rotation.eulerAngles.z < 180)
        {
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }

        //Right drill
        if (xVeloc > 0 && (transform.rotation.z > 340 || transform.rotation.z <= 20))
        {
            transform.Rotate(Vector3.back, TiltSpeed * Time.deltaTime);
        }
        if (transform.rotation.eulerAngles.z < 340 && transform.rotation.eulerAngles.z > 180)
        {
            transform.rotation = Quaternion.Euler(0, 0, 340);
        }

        //Redrill in the middle when no "Left/Right" Button is pressed
        if (xVeloc == 0 && transform.rotation.z != 0)
        {
            if (transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180)
            {
                transform.Rotate(Vector3.back, TiltSpeed * Time.deltaTime);
            }
            if (transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z > 180)
            {
                transform.Rotate(Vector3.forward, TiltSpeed * Time.deltaTime);
            }
        }
    }

    public void ApplyDamage(int damage)
    {
        CurrentHP -= damage;
        if(CurrentHP <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Application.LoadLevel(1);
    }

    // Instantiate a projectile for each WeaponMount
    private void Shoot()
    {

        // Gatling Gun
        Instantiate(GatlingProjectile, GatlingMount.transform.position, transform.rotation);

        // Missiles
        // TODO Missiles

    }
}
