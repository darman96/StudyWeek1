using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Variables
    public float m_moveSpeed = 50f;
    public float m_rotateSpeed = 150f;

    //PlayerCounts
    private int m_playerCount = 1;      //Outsorce to Master Script
    //Velocitys
    private float xVelocityPly1 = 0;
    private float zVelocityPly1 = 0;
    private float xVelocityPly2 = 0;
    private float zVelocityPly2 = 0;
    //Last Buttons Variable
    private string m_lastKey = "";

	// Update is called once per frame
	void Update () {
        switch(m_playerCount) {
            case 1:
                MovementPlayer1();
                break;
            case 2:
                MovementPlayer1();
                MovementPlayer2();
                break;
        }
	}

    void MovementPlayer1() {
        //Modifies Velocities
        xVelocityPly1 = Input.GetAxis("Horizontal Player1") * m_moveSpeed * Time.deltaTime;
        zVelocityPly1 = Input.GetAxis("Vertical Player1") * m_moveSpeed * Time.deltaTime;
        //Interpolite Playerchar
        Rotate(xVelocityPly1, zVelocityPly1);
        transform.Translate(new Vector3(xVelocityPly1, 0, zVelocityPly1), Space.World);
    }
    void MovementPlayer2() {
        //Modifies Velocities
        xVelocityPly2 = Input.GetAxis("Horizontal Player2") * m_moveSpeed * Time.deltaTime;
        zVelocityPly2 = Input.GetAxis("Vertical Player2") * m_moveSpeed * Time.deltaTime;
        //Interpolite Playerchar
        Rotate(xVelocityPly2, zVelocityPly2);
        transform.Translate(new Vector3(xVelocityPly2, 0, zVelocityPly2), Space.World);
    }

    // Tilt the plane when flying left or right
    void Rotate(float xVeloc, float zVeloc) {
        //Left drill
        if(xVeloc < 0 && (transform.rotation.z < 20 || transform.rotation.z >= 340)) {
            transform.Rotate(Vector3.forward, m_rotateSpeed * Time.deltaTime);
        }
        if(transform.rotation.eulerAngles.z > 20 && transform.rotation.eulerAngles.z < 200) {
            transform.rotation = Quaternion.Euler(0, 0, 20);
            m_lastKey = "left";
        }

        //Right drill
        if(xVeloc > 0 && (transform.rotation.z > 340 || transform.rotation.z <= 20)) {
            transform.Rotate(Vector3.back, m_rotateSpeed * Time.deltaTime);
        }
        if(transform.rotation.eulerAngles.z < 340 && transform.rotation.eulerAngles.z > 200) {
            transform.rotation = Quaternion.Euler(0, 0, 340);
            m_lastKey = "right";
        }

        //Redrill in the middle when no "Left/Right" Button is pressed
        if(xVeloc == 0 && transform.rotation.eulerAngles.z != 0) {
            if(transform.rotation.z > 0 && m_lastKey == "right") {
                transform.Rotate(Vector3.back, m_rotateSpeed * Time.deltaTime);
            }
            if(transform.rotation.z < 360 && m_lastKey == "left") { 
                transform.Rotate(Vector3.forward, m_rotateSpeed * Time.deltaTime);
            }
        }
    }
}
