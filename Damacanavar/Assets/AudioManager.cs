using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public List<AudioClip> replikler;
    public List<AudioClip> damacanaReplikler;
    public List<AudioClip> ikinmaSesleri;
    public List<AudioClip> damacanaFirlatmaSesleri;

    public Vector2 interval;
    private AudioSource audioSource;
    private AudioSource musicSource;
    private void Start()
    {
        List<AudioSource> audioSources = new List<AudioSource>(GetComponents<AudioSource>());

        audioSource = audioSources[0];
        musicSource = audioSources[1];

        audioSource.volume = PlayerPrefs.GetFloat("audioVolume", 0.1f);
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume", 0.015f);

        if (!PlayerPrefs.HasKey("audioVolume"))
            PlayerPrefs.SetFloat("audioVolume", audioSource.volume);
        if (!PlayerPrefs.HasKey("musicVolume"))
            PlayerPrefs.SetFloat("musicVolume", musicSource.volume);

        StartCoroutine(PlayReplik());
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    IEnumerator PlayReplik()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(interval.x, interval.y));

            if (!audioSource.isPlaying)
            {
                PlayRandomReplik();
            }
        }
    }

    public void PlayRandomReplik()
    {
        int rnd = Random.Range(0, replikler.Count);
        AudioClip replik = replikler[rnd];

        audioSource.PlayOneShot(replik);
    }
    public void PlayRandomDamacanaReplik()
    {
        if (audioSource.isPlaying)
            return;

        if (Random.Range(0, 20) > 3)
            return;

        int rnd = Random.Range(0, damacanaReplikler.Count);
        AudioClip replik = damacanaReplikler[rnd];
        audioSource.PlayOneShot(replik);
    }

    public void PlayRandomIkinma()
    {
        int rnd = Random.Range(0, ikinmaSesleri.Count);
        AudioClip replik = ikinmaSesleri[rnd];
        audioSource.PlayOneShot(replik, audioSource.volume / 2);
    }
    public void PlayRandomFirlatma()
    {
        int rnd = Random.Range(0, damacanaFirlatmaSesleri.Count);
        AudioClip replik = damacanaFirlatmaSesleri[rnd];
        audioSource.PlayOneShot(replik, audioSource.volume / 2);
    }

}
