using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidToInsightSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int asteroidCount = 11;
    public GameObject target;
    public GameObject[] insightPieces;

    [Header("Orbit Speed")]
    [Range(1f, 50f)]
    [SerializeField] float orbitSpeedMin = 10f;
    [Range(50f, 100f)]
    [SerializeField] float orbitSpeedMax = 100f;
    [Header("Orbit radius")]
    [Range(1f, 10f)]
    [SerializeField] float radiusMin = 4f;
    [Range(20f, 80f)]
    [SerializeField] float radiusMax = 50f;

    public int[] posOrNeg;

    // Start is called before the first frame update
    void Start()
    {
        insightPieces = new GameObject[8];
        StartCoroutine(DelayOnSpawning());
        
    }

    public void SpawnAsteroidsToInsight(int radiusMultiplier)
    {
        insightPieces = GameObject.FindGameObjectsWithTag("InsightPiece");
        Debug.Log("Found " + insightPieces.Length + " InsightPieces.");


        posOrNeg = new int[3];

        /*
        posOrNeg[0] = 1;
        posOrNeg[1] = -1;
        posOrNeg[2] = -3;
        */


        for (int i = 0; i < asteroidCount; i++)
        {
            float orbitSpeedRange = Random.Range(orbitSpeedMin, orbitSpeedMax);
            float radiusRange = Random.Range(radiusMin, radiusMax)* radiusMultiplier;

            int xyz = 0;
            for (xyz = 0; xyz < 3; xyz++)
            {
                posOrNeg[xyz] = Random.Range(0, 2);
                if (posOrNeg[xyz] == 0)
                {
                    posOrNeg[xyz] = -1;
                }
                else
                {
                    posOrNeg[xyz] = 1;
                }

            }


            // Vector3 position = new Vector3(Random.Range(50f, 200f) * posOrNeg[0], Random.Range(50f, 200f) * posOrNeg[1], Random.Range(50f, 200f) * posOrNeg[2]);

            Vector3 offSet = new Vector3(radiusRange, Random.Range(-5f,6f), radiusRange);

            foreach (GameObject insightPiece in insightPieces)
            {
                target = insightPiece;
                GameObject asteroid = Instantiate(asteroidPrefab, insightPiece.transform.position + offSet, transform.rotation);
                asteroid.GetComponent<RedAsteroid>().orbitSpeed = orbitSpeedRange;
                asteroid.GetComponent<RedAsteroid>().radius = radiusRange;
                asteroid.GetComponent<RedAsteroid>().orbitCenter = target.transform.position;
                asteroid.GetComponent<RedAsteroid>().target = insightPiece;
                GameManager.gameManager.AsteroidsSpawnedNumber();
            }


            //GameObject asteroid = Instantiate(asteroidPrefab, position, transform.rotation);

            // xyz = 0;
            GameManager.gameManager.ScoreAsteroids();
        }
    }


    public IEnumerator DelayOnSpawning()
    {
        yield return new WaitForSeconds(3f);
        SpawnAsteroidsToInsight(1);
    }
            

    public void Update()
    {




    }




}
