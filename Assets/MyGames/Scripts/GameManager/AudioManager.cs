using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("XuanTien/AudioManager")]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance
    {
        get => instance;
    }
    private static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSourcePlayer;
    public AudioSource sfxSourceEnemySolider;
    public AudioSource sfxSourceEnemyAttack;

    [Header("Audio Background")]
    public AudioClip backgroundMusic;

    void Start()
    {
        PlayMusic(backgroundMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void PlaySfxPlayer(AudioClip clip)
    {
        sfxSourcePlayer.PlayOneShot(clip);
    }
    public void PlaySfxEnemySolider(AudioClip clip)
    {
        sfxSourceEnemySolider.PlayOneShot(clip);
    }
    public void PlaySfxEnemyAttack(AudioClip clip)
    {
        sfxSourceEnemyAttack.PlayOneShot(clip);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        sfxSourcePlayer.volume = volume;
    }
}
