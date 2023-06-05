using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int asteroidCount = 100;

    [Header("Orbit Speed")]
    [Range(1f, 50f)]
    [SerializeField] float orbitSpeedMin = 10f;
    [Range(50f, 100f)]
    [SerializeField] float orbitSpeedMax = 100f;
    [Header("Orbit radius")]
    [Range(50f, 100f)]
    [SerializeField] float radiusMin = 50f;
    [Range(100f, 500f)]
    [SerializeField] float radiusMax = 200f;

    public int[] posOrNeg;

    // Start is called before the first frame update
    void Start()
    {
        posOrNeg = new int[3];
        
        /*
        posOrNeg[0] = 1;
        posOrNeg[1] = -1;
        posOrNeg[2] = -3;
        */

        for (int i = 0; i < asteroidCount; i++)
        {
            float orbitSpeedRange = Random.Range(orbitSpeedMin, orbitSpeedMax);
            float radiusRange = Random.Range(radiusMin, radiusMax);

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
            
            Vector3 position = new Vector3(Random.Range(50f, 200f) * posOrNeg[0], Random.Range(50f, 200f) * posOrNeg[1], Random.Range(50f, 200f) * posOrNeg[2]);

            GameObject asteroid = Instantiate(asteroidPrefab, position, transform.rotation);
            asteroid.GetComponent<RedAsteroid>().orbitSpeed = orbitSpeedRange;
            asteroid.GetComponent<RedAsteroid>().radius = radiusRange;
            GameManager.gameManager.AsteroidsSpawnedNumber();
            xyz = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
         
            
            

    }
}
