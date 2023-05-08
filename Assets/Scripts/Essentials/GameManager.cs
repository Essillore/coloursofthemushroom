using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int asteroidsDestroyed = 0;
    public int lightsDestroyed = 0;
    public int insightsCollected = 0;

    public int retryCount;

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


    public void InsightsCollected(int insights)
    {
        insightsCollected = insights;
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "InsightCollected", insights, "Insight", "insightCollected" + insightsCollected);
    }

    public void AsteroidDestroyed()
    {
        asteroidsDestroyed += 1;
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
