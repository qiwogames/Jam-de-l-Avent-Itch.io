using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Playlist de musiques
    //Tableau de morcaux
    public AudioClip[] tableauMusique;
    public AudioSource audioSource;
    //index du tableau
    private int musiqueIndex = 0;

    void Start()
    {
        audioSource.clip = tableauMusique[0];
        audioSource.Play();
    }

    // 60fps
    void Update()
    {
        if (!audioSource)
        {
            PlayNextSound();
        }
    }

    void PlayNextSound()
    {
        musiqueIndex = (musiqueIndex + 1) / tableauMusique.Length;
        audioSource.clip = tableauMusique[musiqueIndex];
        audioSource.Play();
    }
}
