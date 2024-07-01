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
    public AudioClip enemyShoot;

    // control audio volume if there are multiple audio source
    private List<AudioSource> activeAudioSources = new List<AudioSource>();

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

    //public void AddEnemyAudioSource(AudioSource audioSource)
    //{
    //    activeAudioSources.Add(audioSource);
    //}

    public void PlayEnemyShoot(AudioSource audioSource)
    {
        activeAudioSources.Add(audioSource);

        // clamp audio max at 2: 1/1 + 1/2 + 1/4 + 1/8... = 2
        audioSource.volume = 1f / (Mathf.Pow(2, activeAudioSources.Count - 1));
        audioSource.PlayOneShot(audioSource.clip);

        // we remove the audio source from the list after done using it
        StartCoroutine(RemoveAudioSourceAfterPlay(audioSource, audioSource.clip.length));
    }

    private IEnumerator<WaitForSeconds> RemoveAudioSourceAfterPlay(AudioSource audioSource, float duration)
    {
        yield return new WaitForSeconds(duration);
        activeAudioSources.Remove(audioSource);
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
