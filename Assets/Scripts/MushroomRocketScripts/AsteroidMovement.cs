using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Transform centerOfOrbit;
    public float orbitSpeed = 10f;


    public float forceToAdd;
   // public float inertia = 0.4f;
   // public float alpha = 2f;
    public float radius = 1;

    // F = m* v^2 / r
    //where forceForce is the force, m is the mass of the object, v is the speed of the object, and r is the radius of the circular path.
    //Inertia is the moment of inertia of the object and
    //alpha is the angular acceleration of the object.

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

       
    }

    void FixedUpdate()
    {
        forceToAdd = rb.mass * (orbitSpeed * orbitSpeed) / radius;

        /* float torqueMagnitude = i * alpha;
         float torqueX = 0;
         float torqueY = torqueMagnitude;
         float torqueZ = 0;
         Vector3 torque = new Vector3(torqueX, torqueY, torqueZ);
         rb.AddTorque(torque);
        */

        float x = Mathf.Cos(Time.time);
        float z = Mathf.Sin(Time.time);
        Vector3 forceVector = new Vector3(x, 0, z) * forceToAdd;
        rb.AddForce(forceVector);
    }
}
