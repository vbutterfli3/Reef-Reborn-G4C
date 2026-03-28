using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXFactory : MonoBehaviour
{
    public static SFXFactory Instance;

    private AudioSource musicSource;
    private AudioSource sfxSource;

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

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.playOnAwake = false;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.playOnAwake = false;

        DontDestroyOnLoad(gameObject);
    }

    public void PlayLevelUp(float volume = 1f) => Play(levelUp, volume);
    public void PlayClip2(float volume = 1f) => Play(throwOuttrash, volume);
    public void PlayClip3(float volume = 0.5f) => Play(wholeGameAudio, volume);
    public void PlaynoPickUp(float volume = 1f) => Play(noPickUp, volume);
    public void PlayClip5(float volume = 1f) => Play(clip5, volume);

    private void Play(AudioClip clip, float volume)
    {
        if (clip == null) return;

        sfxSource.Stop(); // optional: ensures restart
        sfxSource.clip = clip;
        sfxSource.volume = volume;
        sfxSource.pitch = Random.Range(0.95f, 1.05f); // optional polish
        sfxSource.Play();
    }

    public void PlayLoop(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.volume = volume;
        musicSource.Play();
    }
}