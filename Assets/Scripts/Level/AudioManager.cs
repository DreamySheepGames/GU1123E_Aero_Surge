using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Player Audio Clip")]
    public AudioClip background;
    public AudioClip playerExplode;
    public AudioClip playerRevive;
    public AudioClip playerLevelUp;
    public AudioClip playerShoot;

    [Header("Enemy Audio Clip")]
    public AudioClip enemyExplode;

    private void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.Play();
    }
}
