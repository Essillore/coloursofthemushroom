using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsightSpawner : MonoBehaviour
{
    public GameObject mushroomCollectingColours;

    public GameObject[] insightPuzzles;
    public bool[] pieces;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(Random.Range(-200f, 200f), Random.Range(-200f, 200f), Random.Range(-200f, 200f));

      
        pieces = new bool[7];

            for (int i = 0; i < 7; i++)
            {
            
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
