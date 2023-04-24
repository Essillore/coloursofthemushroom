using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAsteroid : MonoBehaviour
{
    public Vector3 orbitCenter;
    public float orbitSpeed = 10f;


    public float forceToAdd;
    public float inertia = 0.4f;
    public float alpha = 2f;
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
        float orbitCircumference = 2 * Mathf.PI * radius;
        float orbitTime = orbitCircumference / orbitSpeed;
        float orbitAcceleration = (2 * Mathf.PI) / orbitTime;
        forceToAdd = rb.mass * orbitAcceleration;

         float torqueMagnitude = inertia * alpha;
         float torqueX = 0;
         float torqueY = torqueMagnitude;
         float torqueZ = 0;
         Vector3 torque = new Vector3(torqueX, torqueY, torqueZ);
         rb.AddTorque(torque);
        

        Vector3 orbitDirection = transform.position - orbitCenter;
        orbitDirection = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0) * orbitDirection;
        transform.position = orbitCenter + orbitDirection.normalized * radius;


        //Vector3 forceVector = new Vector3(x, 0, z) * forceToAdd;
        //rb.AddForce(forceVector);
    }
}
