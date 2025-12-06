using System.Collections;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public AudioClip[] soundList;
    public float minTimeBetweenSounds = 1.0f;
    public float maxTimeBetweenSounds = 3.0f;

    public AudioSource audioSource;
    private bool isPlaying;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPlaying = false;

        // Start the coroutine to play random sounds
        StartCoroutine(PlayRandomSoundWithInterval());
    }

    IEnumerator PlayRandomSoundWithInterval()
    {
        while (true)
        {
            if (!isPlaying)
            {
                // Wait for a random time interval before playing the next sound
                float interval = Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
                yield return new WaitForSeconds(interval);

                // Play a random sound from the list
                PlayRandomSound();
            }

            yield return null;
        }
    }

    void PlayRandomSound()
    {
        if (soundList.Length == 0)
        {
            Debug.LogWarning("No sounds in the list!");
            return;
        }

        int randomIndex = Random.Range(0, soundList.Length);
        AudioClip randomClip = soundList[randomIndex];

        if (randomClip)
        {
            audioSource.PlayOneShot(randomClip);
            isPlaying = true;
            StartCoroutine(WaitForSoundToEnd(randomClip.length));
        }
    }

    IEnumerator WaitForSoundToEnd(float soundLength)
    {
        yield return new WaitForSeconds(soundLength);
        isPlaying = false;
    }
}
