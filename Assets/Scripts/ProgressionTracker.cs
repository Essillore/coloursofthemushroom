using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

public class ProgressionTracker : MonoBehaviour
{
   // Start is called before the first frame update
    void Start()
    {

    }

    public int asteroidsDestroyed;

    private int retryCount;

    // Update is called once per frame
    void Update()
    {
        retryCount = GameManager.gameManager.retryCount;

        // GA_Resource.NewEvent(GAResourceFlowType.Source, "AsteroidsDestroyed", 100, "Currency", "Coins100", null, false);

        // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World1", score);
       // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World1", "Level1");
       // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World1", "Level1", score);
       // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World1", "Level1", "Phase1");
       // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World1", "Level1", "Phase1", score);

        // Using 3 progression parts (01+02+03) and score
       // GameAnalytics.NewProgressionEvent(GA_Progression.GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score)

    }

    public void PlayerRestartedLevel()
    {
        GameManager.gameManager.RetrySphereWorld();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "SphereWorld", "Retry", retryCount);
    }

    public void PlayerRestartBorrowedTime()
    {
        GameManager.gameManager.RetrySphereWorld();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "SphereWorld", "BorrowedTime", retryCount);
    }



}