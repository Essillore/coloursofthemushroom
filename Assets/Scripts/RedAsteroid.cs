using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAsteroid : MonoBehaviour
{
    public Vector3 orbitCenter;
    public GameObject target;
    public float orbitSpeed = 10f;


    public float forceToAdd;
    public float inertia = 0.4f;
    public float alpha = 2f;
    public float radius = 1;

    private AsteroidHealth asteroidHealth;
    private Rigidbody rb;
    private bool hasCollided = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asteroidHealth = GetComponent<AsteroidHealth>();       
    }

    void FixedUpdate()
    {

       //Attempts to make asteroid follow the insight piece, if that was it's orbit center,
       //even when the insight piece teleports,
       //with delaying checking where the insight piece
       //and to make asteroids that spawn with the insight piece already collected, 
       //to orbit the center instead
       //does not work as intended.
        if (target != null)
        {
            orbitCenter = target.transform.position;
        }
        if (target = null)
        {
            StartCoroutine(WaitToCheckWhereInsight());
        }



        //Unnecessarily complicated physics for asteroid movement,
        //in an attempt to understand better how physics work.
        //Asteroid rotates with physics (torque)
        //but moves with transform.position

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

    }



    private void OnCollisionEnter(Collision collision)
    {
        // Check if collision has already occurred,
        // to make the same asteroid do dmg to player only once,
        // even with its delayed destruction
        if (hasCollided)
        {
            return;
        }


        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        //When touch player, player takes 20dmg,
        //in 0.5s asteroid takes 100 dmg -> destroys -> explodes -> spawns light
        if (playerHealth)
        {
            playerHealth.TakeDamage(20);
            StartCoroutine(DelayOnDestroy());

            //Same asteroid collides only once with player
            hasCollided = true;
        }

    }
        private IEnumerator DelayOnDestroy()
        {
            yield return new WaitForSeconds(0.5f);
            
            asteroidHealth.TakeDamage(100);

        }

        private IEnumerator WaitToCheckWhereInsight()
    {
        yield return new WaitForSeconds(0.2f);

        if (target = null)
        {
            orbitCenter = new Vector3(0, 0, 0);
        }
    }
}
