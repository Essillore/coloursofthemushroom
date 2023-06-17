using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreaksSoundPlayer : MonoBehaviour
{
    public AudioClip[] glassBreaks;
    AudioSource audioSource;

    public int glassSoundRandomiser = 3;
    public AudioClip whichSoundToPlay;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        glassSoundRandomiser = Random.Range(0, 5);
        print(glassSoundRandomiser);
        whichSoundToPlay = glassBreaks[glassSoundRandomiser];

        OnLightShattered();
    }

    public void OnLightShattered()
    {
        
        audioSource.PlayOneShot(whichSoundToPlay, 0.7F);
    }
}
