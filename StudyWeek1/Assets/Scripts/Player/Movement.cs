using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    //Variables
    public float moveSpeed = 50f;
    public float rotateSpeed = 150f;
    public int PlayerNumber = 1;
    private int PlayerCount = 1;

    //Velocitys
    private float xVelocityPly1 = 0;
    private float zVelocityPly1 = 0;
    private float xVelocityPly2 = 0;
    private float zVelocityPly2 = 0;

    void Start()
    {
        //PlayerCount = GameObject.Find("Master-Indestructable").GetComponent<Master>().m_playerCount;
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerCount)
        {
            case 1:
                MovementPlayer1();
                break;
            case 2:
                if (PlayerNumber == 1)
                {
                    MovementPlayer1();
                }
                if (PlayerNumber == 2)
                {
                    MovementPlayer2();
                }
                break;
        }
    }

    void MovementPlayer1()
    {
        //Modifies Velocities
        xVelocityPly1 = Input.GetAxis("Horizontal Player1") * moveSpeed * Time.deltaTime;
        zVelocityPly1 = Input.GetAxis("Vertical Player1") * moveSpeed * Time.deltaTime;
        //Interpolite Playerchar
        Rotate(xVelocityPly1, zVelocityPly1);
        transform.Translate(new Vector3(xVelocityPly1, 0, zVelocityPly1), Space.World);
    }
    void MovementPlayer2()
    {
        //Modifies Velocities
        xVelocityPly2 = Input.GetAxis("Horizontal Player2") * moveSpeed * Time.deltaTime;
        zVelocityPly2 = Input.GetAxis("Vertical Player2") * moveSpeed * Time.deltaTime;
        //Interpolite Playerchar
        Rotate(xVelocityPly2, zVelocityPly2);
        transform.Translate(new Vector3(xVelocityPly2, 0, zVelocityPly2), Space.World);
    }

    // Tilt the plane when flying left or right
    void Rotate(float xVeloc, float zVeloc)
    {
        //Left drill
        if (xVeloc < 0 && (transform.rotation.z < 20 || transform.rotation.z >= 340))
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (transform.rotation.eulerAngles.z > 20 && transform.rotation.eulerAngles.z < 180)
        {
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }

        //Right drill
        if (xVeloc > 0 && (transform.rotation.z > 340 || transform.rotation.z <= 20))
        {
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
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
                transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
            }
            if (transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z > 180)
            {
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            }
        }
    }
}
