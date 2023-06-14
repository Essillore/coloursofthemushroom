using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsightMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float inertia = 0.4f;
    public float alpha = 2f;
    public int insightNumber;
    public GameObject insightSpawner;
    Vector3 torque;
    public bool freeze = false;
    SpinMushroomHat hatSpinner;
    public GameObject playerHealth;
    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GameObject.FindWithTag("Player");
        timer = GameObject.FindWithTag("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            float torqueMagnitude = inertia * alpha;
            float torqueX = torqueMagnitude;
            float torqueY = torqueMagnitude;
            float torqueZ = torqueMagnitude;
            torque = new Vector3(torqueX, torqueY, torqueZ);
            rb.AddTorque(torque);
        }
        else if (freeze)
        {
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }        
    }

    public void Teleport()
    {
        Vector3 position = new Vector3(Random.Range(-200f, 200f), Random.Range(-200f, 200f), Random.Range(-200f, 200f));
        transform.position = position;
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerIsNear = other.gameObject.GetComponent<PlayerHealth>();
        if (playerIsNear)
        {
            Collect();
        }
    }


    public void Collect()
    {
       
        InsightSpawner insightTracker = insightSpawner.GetComponent<InsightSpawner>();
        insightTracker.InsightCollected(insightNumber);
        playerHealth.GetComponent<PlayerHealth>().Heal();
        timer.GetComponent<Timer>().InsightCollectedTime();
        Destroy(gameObject);
        
       // insightTracker.pieces[insightNumber] = true;



        // insightTracker().pieces(insightNumber) = true;
        //play animation
        // Send message to gamemanager that this piece is collected
        //gamemanager sends message to player shader/material? to visualize progress
        //Placeholder: score to ui.

    }

}
