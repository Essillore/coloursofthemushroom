using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;



    public FootVisualiseHealth healthShower;
    public LevelManager levelManager;

    public PauseScript pauseScript;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            TakeDamage(20);
            print("Lost 20 hp");
        }


    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthShower.CheckIfFootNeedsChanged(currentHealth);

        if (currentHealth <= 0)
        {
            pauseScript.PlayerDied();
        }

    }
}
