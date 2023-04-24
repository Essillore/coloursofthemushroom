using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    public GameObject lightBall;
    public float lightBallSpeed = 1000f;

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
            nextFire = Time.time + fireRate;
            GameObject projectile = Instantiate(lightBall, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * lightBallSpeed);
            print(transform.forward * lightBallSpeed);
        }
    }

}
