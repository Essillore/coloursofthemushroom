using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBall : MonoBehaviour
{
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //print(this.GetComponent<Rigidbody>().velocity.magnitude.ToString());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Asteroids that have rigid body
        RedAsteroid asteroidClash = collision.gameObject.GetComponent<RedAsteroid>();
        AsteroidMovement asteroidClashBlack = collision.gameObject.GetComponent<AsteroidMovement>();
        
        //Asteroid health
        AsteroidHealth asteroidHealth = collision.gameObject.GetComponent<AsteroidHealth>();

        //Insight piece
        InsightMovement insightPiece = collision.gameObject.GetComponent<InsightMovement>();

        //When touch asteroid, asteroid takes 100 dmg -> destroys -> explodes -> spawns light
        if (asteroidClash | asteroidClashBlack)
        {   
            asteroidHealth.TakeDamage(100);
        }
        else if (insightPiece)
        {
            insightPiece.Teleport();
        }

    }
}


   