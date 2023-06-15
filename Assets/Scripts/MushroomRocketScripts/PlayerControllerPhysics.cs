using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPhysics : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float turnSpeed = 5f;
    public float hor;
    public float ver;
    public float dep;
    public float roll;

    Rigidbody myRB;

    void Start()
    {
      myRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //keybinds in Input manager for movement
        //ver, forward/backwards (movement), space & B
        //hor, turn, A & D
        //dep, turn, W & S
        //roll, turn, Q & E
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        dep = Input.GetAxis("Depth");
        roll = Input.GetAxis("Roll");

        //Move player forward
        myRB.AddRelativeForce(Vector3.forward * myRB.mass * ver * playerSpeed, ForceMode.Force);

        //Turn player horizontally (yaw)
        myRB.AddRelativeTorque(Vector3.up * myRB.mass * hor * turnSpeed);

        //Turn player up and down (pitch)
        myRB.AddRelativeTorque(Vector3.right *(-1)* myRB.mass * dep * turnSpeed);

        //Turn player around local Y-axis (roll)
        myRB.AddRelativeTorque(Vector3.forward * myRB.mass * roll * turnSpeed);
        }
}
