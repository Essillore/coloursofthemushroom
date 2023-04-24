using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int asteroidCount = 100;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            float orbitSpeedRange = Random.Range(20f, 100f);
            float radiusRange = Random.Range(20f, 200f);

            Vector3 position = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));

            GameObject asteroid = Instantiate(asteroidPrefab, position, transform.rotation);
            asteroid.GetComponent<RedAsteroid>().orbitSpeed = orbitSpeedRange;
            asteroid.GetComponent<RedAsteroid>().radius = radiusRange;
        }

    }

    // Update is called once per frame
    void Update()
    {
         
            
            

    }
}
