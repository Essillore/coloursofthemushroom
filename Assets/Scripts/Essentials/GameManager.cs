using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int asteroidsDestroyed = 0;
    public int lightsDestroyed = 0;
    public int insightCollected = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }        
    }

    public void AsteroidDestroyed()
    {
        asteroidsDestroyed += 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
