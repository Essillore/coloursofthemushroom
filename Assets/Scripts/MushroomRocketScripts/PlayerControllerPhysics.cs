using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPhysics : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
    public float dep;
    public float roll;

    Rigidbody myRB;


    // Start is called before the first frame update
    void Start()
    {
      myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // keybinds in Input manager for movement
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        dep = Input.GetAxis("Depth");
        roll = Input.GetAxis("Roll");

        //To solve
        //Is (ForceMode.Force (( force * DT / mass) * mass) the same as
        // ForceMode.Acceleration  ( force * DT)?

        //Move player forward
        myRB.AddRelativeForce(Vector3.forward * myRB.mass * ver * playerSpeed, ForceMode.Acceleration);

        print(myRB.velocity);

        // Move player up and down
        myRB.AddRelativeForce(Vector3.up * myRB.mass * dep * playerSpeed, ForceMode.Acceleration);

        print(myRB.velocity);

        //Turn player horizontally with A and D
        //To solve: Slows down movement 
        myRB.AddRelativeTorque(Vector3.up * myRB.mass * hor);

        //Roll player around local Y-axis
        myRB.AddRelativeTorque(Vector3.forward * myRB.mass * roll);

    /*    Vector3 tempVect = new Vector3(hor, dep, ver);
        tempVect = tempVect.normalized * playerSpeed * Time.deltaTime;
      myRB.MovePosition(transform.position + tempVect);
    */
        }
}
