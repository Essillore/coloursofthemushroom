using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBall : MonoBehaviour
{
    public GameObject explosionEffect;

    void Start()
    {
        Destroy(gameObject, 5f);
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

        LightHealth littleLight = collision.gameObject.GetComponent<LightHealth>();

        //When touch asteroid, asteroid takes 100 dmg -> destroys -> explodes -> spawns light
        if (asteroidClash | asteroidClashBlack)
        {
            asteroidHealth.TakeDamage(100);
        }
        else if (insightPiece)
        {
            insightPiece.Teleport();
        }
        else if (littleLight)
        {
            print("Hit light physically");
            //commented away to make accidentally destroying lights harder
            //littleLight.TakeDamage(20);
        }

    }
}


   