using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseMenu;
    public GameObject deadMenu;
    public PlayerHealth playerHealth;
    public GameObject timerHolder;

    void Start()
    {
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
    }

    void Update()
    {

        // Button to toggle pause boolean
        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;
        }

        // Pauses the game and opens the menu
        if (paused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (!paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void PlayerDied()
    {
        paused = true;
        deadMenu.SetActive(true);
    }

    //Allow player to continue when health 0, set player health to full, disables timer.
    public void BorrowedTime()
    {
        paused = false;
        playerHealth.TakeDamage(-100);
        deadMenu.SetActive(false);
        timerHolder.GetComponent<Timer>().TimedModeSetting(false);
    }

}
