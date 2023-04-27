using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    public GameObject lightBall;
    public float lightBallSpeed = 60000f;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;



//     public Rigidbody myRB;


    // Start is called before the first frame update
    void Start()
    {
   //     myRB = GetComponentInParent<PlayerControllerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Vector3 aimDir = (MousePosition.GetMouseWorldPosition() - transform.position).normalized;
            nextFire = Time.time + fireRate;
            GameObject projectile = Instantiate(lightBall, transform.position, transform.rotation);
            // Quaternion.LookRotation(aimDir, Vector3.up)
            projectile.GetComponent<Rigidbody>().AddForce(aimDir * lightBallSpeed);
           // print(transform.forward * lightBallSpeed);
        }


    }

}
