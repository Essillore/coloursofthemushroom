using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int asteroidMaxHealth = 100;
    public int asteroidCurrentHealth;

    public GameObject prettyLight;
    public GameObject explosionEffect;

    void Start()
    {
        asteroidCurrentHealth = asteroidMaxHealth;
    }

    public void Health()
    {

        if (asteroidCurrentHealth <= 0)
        {
            GameObject lightSphere = Instantiate(prettyLight, transform.position, transform.rotation);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            GameManager.gameManager.AsteroidDestroyed();
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int amount)
    {
        asteroidCurrentHealth -= amount;
        Health();

    }




}
