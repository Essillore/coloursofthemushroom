using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int asteroidMaxHealth = 100;
    public int asteroidCurrentHealth;

    public GameObject prettyLight;
    public GameObject explosionEffect;


    // Start is called before the first frame update
    void Start()
    {
        asteroidCurrentHealth = asteroidMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Health()
    {

        if (asteroidCurrentHealth <= 0)
        {
            GameObject lightSphere = Instantiate(prettyLight, transform.position, transform.rotation);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int amount)
    {
        asteroidCurrentHealth -= amount;
        Health();

    }
}
