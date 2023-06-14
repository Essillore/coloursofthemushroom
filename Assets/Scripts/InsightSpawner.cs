using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

public class InsightSpawner : MonoBehaviour
{
    public GameObject mushroomCollectingColours;

    public GameObject[] insightPuzzles;
    public bool[] pieces;
    public int insightCounter;

    public LevelManager levelManager;
    public AsteroidToInsightSpawner asteroidSpawner;

    // Start is called before the first frame update
    void Start()
    {
      //  int howManyInsightYouCollectedBeforeYouDied;
      
        pieces = new bool[7];

            for (int i = 0; i < 7; i++)
            {
            Vector3 position = new Vector3(Random.Range(-200f, 200f), Random.Range(-200f, 200f), Random.Range(-200f, 200f));
            
            GameObject insightPiece = Instantiate(insightPuzzles[i], position, transform.rotation);

            insightPiece.GetComponent<InsightMovement>().insightSpawner = gameObject;
            insightPiece.GetComponent<InsightMovement>().insightNumber = i;
                pieces[i] = false;
        }


    }

    public void InsightCollected(int numberOfPiece)
    {

     

        pieces[numberOfPiece] = true;
        mushroomCollectingColours.GetComponent<ColoursCollected>().WhichInsightWasCollected(numberOfPiece);
        insightCounter++;
        asteroidSpawner.SpawnAsteroidsToInsight(insightCounter+1);
        WinCondition();
       
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinCondition()
    {
        if (insightCounter==7)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "SphereWorld", GameManager.gameManager.HowManyAsteroidsDestroyed());
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "AsteroidsDestroyed", GameManager.gameManager.HowManyAsteroidsDestroyed(), "Asteroid", "asteroidsDestroyed");

            levelManager.ChangeLevel(4);
        }
    }

    public void NumberOfInsightCollected()
    {
        // this is obviously not complete yet
        foreach (bool value in pieces)
        {
            print(value);
            if (value == true)
            {
                
            }

        }
    }


    
}
