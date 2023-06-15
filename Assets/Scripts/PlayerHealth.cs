using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public FootVisualiseHealth healthShower;
    public LevelManager levelManager;

    public PauseScript pauseScript;

    void Start()
    {
        currentHealth = maxHealth;
    }

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
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "SphereWorld", GameManager.gameManager.HowManyAsteroidsDestroyed());
            pauseScript.PlayerDied();
        }

    }

    public void Heal()
    {
        currentHealth = maxHealth;
        healthShower.CheckIfFootNeedsChanged(currentHealth);
    }

}
