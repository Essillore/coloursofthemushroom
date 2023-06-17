using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Events;

public class LevelChangerTrigger : MonoBehaviour
{

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (player)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Tutorial");
            levelManager.ChangeLevel(2);
        }
    }

}
