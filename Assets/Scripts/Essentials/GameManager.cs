using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int asteroidsDestroyed = 0;
    public int asteroidsSpawned = 0;
    public int lightsDestroyed = 0;
    public int insightsCollected = 0;
    public int numberOfShootLight = 0;
    public float accuracy;

    public int retryCount;

    public GameObject scorePanel;
    public TMP_Text scoreString;
    public GameObject accuracyPanel;
    public TMP_Text accuracyString;

    void Start()
    {
        GameAnalytics.Initialize();
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
        retryCount = 0;
    }

    private void FixedUpdate()
    {
        AccuracyPercentage();
        //Lightweight check to know, when player has restarted the level
        //as the game manager is persistent.
        if (scorePanel == null)
        {
            Retry();
        }
    }

    //Finds score/accuracy UI elements, and resets stats, when player restarts a level.
    public void Retry()
    {
        scorePanel = GameObject.FindWithTag("ScoreUI");
        scoreString = scorePanel.GetComponentInChildren<TMP_Text>();
        accuracyPanel = GameObject.FindWithTag("AccuracyUI");
        accuracyString = accuracyPanel.GetComponentInChildren<TMP_Text>();
        asteroidsDestroyed = 0;
        asteroidsSpawned = 100;
        numberOfShootLight = 0;
    }



    public void AsteroidsSpawnedNumber()
    {
        asteroidsSpawned += 1;
    }

    public void AsteroidDestroyed()
    {
        asteroidsDestroyed += 1;
        ScoreAsteroids();
    }

    public void ScoreAsteroids()
    {
        scoreString.text = "Asteroids " + asteroidsDestroyed.ToString() + " / " + asteroidsSpawned.ToString();
    }

    //How many times the player has shot a LMB lightbullet. Used to calculate accuracy.
   public void NumberOfShots()
    {
        numberOfShootLight += 1;
    }

    //Issue with accuracy: Player can destroy two asteroids at one shot
    //(to make shooting feel smoother,
    //the shot instantiates a lightbullet,
    //but also directly destroys asteroid if hit on click)
    //Accuracy hid for now.
    public void AccuracyPercentage()
    {
        accuracy = ((float)asteroidsDestroyed / (float)numberOfShootLight) * 100;
        ScoreAccuracy();
    }

    public void ScoreAccuracy()
    {
        string accuracyText = "";
        if (!double.IsNaN(accuracy) && !double.IsInfinity(accuracy))
        {
            accuracyText = "Accuracy " + accuracy.ToString("F2") + " %";
        }
        accuracyString.text = accuracyText;
    }

    public int HowManyAsteroidsDestroyed()
    {
        return asteroidsDestroyed;
    }

    public void RetrySphereWorld()
    {
        retryCount++;
    }
}
