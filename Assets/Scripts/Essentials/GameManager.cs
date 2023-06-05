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

    // Start is called before the first frame update
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


    private void FixedUpdate()
    {
        AccuracyPercentage();

        if (scorePanel == null)
        {
            Retry();
        }
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

   public void NumberOfShots()
    {
        numberOfShootLight += 1;
    }

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


    // Update is called once per frame
    void Update()
    {
        
    }



}
