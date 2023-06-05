using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 70f;
    public float startTime;

    public PauseScript pauseScript;
    public GameObject timedMenu;
    public TMP_Text timerString;

    public bool timedMode = true;

    // Start is called before the first frame update
    void Start()
    {
        if (timedMode == true)
        {
            timedMenu.SetActive(true);
        }
        if (timedMode == false)
        {
            timedMenu.SetActive(false);
        }
        timer = 70f;
        startTime = Time.time;
        StartCoroutine(TimeToPlay());


    }

    public void TimedModeSetting(bool isTimedMode)
    {
        if (isTimedMode == true)
        { 
            timedMode = true;
            timedMenu.SetActive(true);
        }
        if (isTimedMode == false)
        {
            timedMode = false;
            timedMenu.SetActive(false);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft();
    }

    public IEnumerator TimeToPlay()
    {
        while (timer > 0)
        {

        yield return new WaitForSeconds(1f);
        timer -= 1f;
        }

        if (timer <= 0f && timedMode == true)
        {
            pauseScript.PlayerDied();
        }
    }

    public void TimeLeft()
    {
        timerString.text = "Time " + timer.ToString();
    }

    public void InsightCollectedTime()
    {
        timer += 40f;
    }


}
