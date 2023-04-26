using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsightSpawner : MonoBehaviour
{
    public GameObject insightPiece3;

        public GameObject[] insightPuzzles;
    public bool[] pieces;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(Random.Range(-200f, 200f), Random.Range(-200f, 200f), Random.Range(-200f, 200f));

       /*  foreach (bool value in pieces)
        {
            print(value);
         }
        */
        pieces = new bool[8];

            for (int i = 0; i < 8; i++)
            {
            
            GameObject insightPiece = Instantiate(insightPuzzles[i], position, transform.rotation);

            insightPiece.GetComponent<InsightMovement>().insightNumber = i;
                pieces[i] = false;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
