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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
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

        }
              
    }

    public void Teleport()
    {
        Vector3 position = new Vector3(Random.Range(-200f, 200f), Random.Range(-200f, 200f), Random.Range(-200f, 200f));
        transform.position = position;
    }

    public void Collect()
    {
        InsightSpawner insightTracker = insightSpawner.GetComponent<InsightSpawner>();
       // insightTracker.pieces[insightNumber] = true;

        insightTracker.InsightCollected(insightNumber);

        Destroy(gameObject);

        // insightTracker().pieces(insightNumber) = true;
        //play animation
        // Send message to gamemanager that this piece is collected
        //gamemanager sends message to player shader/material? to visualize progress
        //Placeholder: score to ui.

    }

}
