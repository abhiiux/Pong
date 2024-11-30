using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource audioSource2;
    public AudioClip boundary;
    public AudioClip paddle;
    public AudioClip gameOver;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
    }
    public void HitBoundary()
    {
        audioSource.clip = boundary;
        audioSource.Play();
    }
    public void HitPaddle()
    {
        audioSource2.clip = paddle;
        audioSource2.Play();
    }
    public void Over()
    {
        audioSource2.clip = gameOver;
        audioSource2.Play();
    }
}
