using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayerUnderhat : MonoBehaviour
{
    public AudioClip[] insightCollectedSounds;
    AudioSource audioSource;

    public int insightSoundRandomiser = 3;
    public AudioClip whichSoundToPlay;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        insightSoundRandomiser = Random.Range(0, 2);
        whichSoundToPlay = insightCollectedSounds[insightSoundRandomiser];

        OnInsightCollected();
    }

    public void OnInsightCollected()
    {
        audioSource.PlayOneShot(whichSoundToPlay, 0.7F);
    }
}
