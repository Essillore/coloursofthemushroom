using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsightSpawner : MonoBehaviour
{
    public GameObject mushroomCollectingColours;

    public GameObject[] insightPuzzles;
    public bool[] pieces;
    public int insightCounter;

    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        int howManyInsightYouCollectedBeforeYouDied;
      
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

    //   if(insightSpawner.GetComponent<InsightSpawner>().pieces[i] == true)
     //   { 
             
      //  }

    public void InsightCollected(int numberOfPiece)
    {
        pieces[numberOfPiece] = true;
        mushroomCollectingColours.GetComponent<ColoursCollected>().WhichInsightWasCollected(numberOfPiece);
        insightCounter++;
        GameManager.gameManager.InsightsCollected(insightCounter);
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
            levelManager.ChangeLevel(4);
        }
    }

    public void NumberOfInsightCollected()
    {
        
        foreach (bool value in pieces)
        {
            print(value);
            if (value == true)
            {
                
            }

        }
    }


    
}
