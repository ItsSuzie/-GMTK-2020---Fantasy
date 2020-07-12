using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip[] glitchyClips;
    public AudioClip backgroundMusic;
    private float bgMusicCurrentTime;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // play bg music
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        audioSource.loop = true;
    }

    public void playGlitchyClip(int index)
    {
        // if index is legal
        if(index < glitchyClips.Length - 1)
        {
            // get the current time of the bacground
            bgMusicCurrentTime = audioSource.time;
            audioSource.Stop();

            // Pause current track
            audioSource.PlayOneShot(glitchyClips[index]);

            Invoke("returnBGMusic", glitchyClips[index].length);
        }
    }

    private void returnBGMusic()
    {
        audioSource.time = bgMusicCurrentTime;
        audioSource.Play();
    }

    // todo: when files exist, do speicific things to the music
    // like reverse controlles, wobble the pitch


}
