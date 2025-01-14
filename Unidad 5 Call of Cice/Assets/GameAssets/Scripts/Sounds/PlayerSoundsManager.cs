﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundsManager : MonoBehaviour
{
    private AudioSource aSource;
    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

    private void Start()
    {
        aSource = GetComponentInParent<AudioSource>();
    }

    public void ManageWalkSound()
    {
        if (aSource.isPlaying) aSource.Stop();
        aSource.clip = audioClips[0];
        aSource.loop = true;
        aSource.Play();
    }

    public void ManageJumpSound()
    {
        aSource.PlayOneShot(audioClips[1]);
    }

    public void ManageRunSound()
    {
        if (aSource.isPlaying) aSource.Stop();
        aSource.clip = audioClips[2];
        aSource.loop = true;
        aSource.Play();
    }

    public void StopSound()
    {
        aSource.Stop();
    }
}
