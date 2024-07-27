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

    //audio
    public AudioClip[] insightCollectedSounds;
    AudioSource audioSource;

    public int insightSoundRandomiser = 3;
    public AudioClip whichSoundToPlay;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        mushroomCollectingColours = GameObject.FindWithTag("ColourCollecterMushroom");

        pieces = new bool[8];

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
        //play audio sound for insightCollected (random of options)
        insightSoundRandomiser = Random.Range(0, 2);
        whichSoundToPlay = insightCollectedSounds[insightSoundRandomiser];
        audioSource.PlayOneShot(whichSoundToPlay, 0.7F);

        //spawn asteroids
        asteroidSpawner.SpawnAsteroidsToInsight(insightCounter+1);

        //check if player won
        WinCondition();    
    }  

    public void WinCondition()
    {
        if (insightCounter==7)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "SphereWorld", GameManager.gameManager.HowManyAsteroidsDestroyed());
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "AsteroidsDestroyed", GameManager.gameManager.HowManyAsteroidsDestroyed(), "Asteroid", "asteroidsDestroyed");

            levelManager.ChangeLevel(3);
        }
    }
}
