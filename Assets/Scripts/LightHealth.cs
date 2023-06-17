using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHealth : MonoBehaviour
{
    public int lightMaxHealth = 20;
    public int lightCurrentHealth;

    public GameObject lightHolder;
    //replace with new effect, shrinking and "black hole" when that's done
    public GameObject lightImplosionEffect;
    void Start()
    {
    lightCurrentHealth = lightMaxHealth;
    lightHolder = transform.parent.gameObject; 

    }

    public void TakeDamage(int amount)
    {
        lightCurrentHealth -= amount;

        Health();
    }

    public void Health()
    {

        if (lightCurrentHealth <= 0)
        {
            Instantiate(lightImplosionEffect, transform.position, transform.rotation);
            Destroy(lightHolder);
        }
    }

    
}
