using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXFactory : MonoBehaviour
{
    public static SFXFactory Instance;

    [Header("Clips")]
    public AudioClip levelUp;
    public AudioClip throwOuttrash;
    public AudioClip wholeGameAudio;
    public AudioClip noPickUp;
    public AudioClip clip5;

    private AudioSource source;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
    }

    public void PlayLevelUp(float volume = 1f) => Play(levelUp, volume);
    public void PlayClip2(float volume = 1f) => Play(throwOuttrash, volume);
    public void PlayClip3(float volume = 1f) => Play(wholeGameAudio, volume);
    public void PlaynoPickUp(float volume = 1f) => Play(noPickUp, volume);
    public void PlayClip5(float volume = 1f) => Play(clip5, volume);

    private void Play(AudioClip clip, float volume)
    {
        if (clip == null) return;

        source.Stop(); // optional: ensures restart
        source.clip = clip;
        source.volume = volume;
        source.pitch = Random.Range(0.95f, 1.05f); // optional polish
        source.Play();
    }
}