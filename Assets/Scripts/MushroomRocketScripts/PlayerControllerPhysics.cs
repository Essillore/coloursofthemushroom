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
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        dep = Input.GetAxis("Depth");
        roll = Input.GetAxis("Roll");

        myRB.AddForce(Vector3.forward * myRB.mass * ver * playerSpeed);
        myRB.AddForce(Vector3.up * myRB.mass * dep * playerSpeed);

        myRB.AddTorque(Vector3.up * myRB.mass * hor);

        myRB.AddTorque(Vector3.forward * myRB.mass * roll);

    /*    Vector3 tempVect = new Vector3(hor, dep, ver);
        tempVect = tempVect.normalized * playerSpeed * Time.deltaTime;
      myRB.MovePosition(transform.position + tempVect);
    */
        }
}
