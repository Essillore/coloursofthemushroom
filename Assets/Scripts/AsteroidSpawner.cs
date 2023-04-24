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
    [Range(5f, 50f)]
    [SerializeField] float radiusMin = 20f;
    [Range(50f, 500f)]
    [SerializeField] float radiusMax = 200f;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            float orbitSpeedRange = Random.Range(orbitSpeedMin, orbitSpeedMax);
            float radiusRange = Random.Range(radiusMin, radiusMax);

            Vector3 position = new Vector3(Random.Range(-200f, 200f), Random.Range(-200f, 200f), Random.Range(-200f, 200f));

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
