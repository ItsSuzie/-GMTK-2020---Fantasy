using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip[] glitchyClips;
    public AudioClip backgroundMusic;

    private float bgMusicCurrentTime;
    private AudioSource audioSource;
    private fileIOManager IOmanager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        IOmanager = GetComponent<fileIOManager>();

        // play bg music
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        audioSource.loop = true;

        //IOmanager.createFileFromString("Glitch");
    }

    private void Update() {

        // if (IOmanager.isFileExists(IOmanager.audioGlitchFiles[0])) {
        //     if (audioSource.pitch != 5)
        //     {
        //         audioSource.pitch = audioSource.pitch < 5 ? Time.deltaTime * audioSource.pitch / 5f : -(Time.deltaTime * audioSource.pitch / 5f);
        //     }
        // }
        // else if (IOmanager.isFileExists(IOmanager.audioGlitchFiles[1])) {
        //     if (audioSource.pitch != .5)
        //     {
        //         audioSource.pitch = audioSource.pitch < .5 ? Time.deltaTime * audioSource.pitch / 5f : -(Time.deltaTime * audioSource.pitch / 5f);
        //     }
        // }
        // else {
        //     audioSource.pitch = 0;
        // }
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

    public float pitch 
    {
        set {audioSource.pitch = value;}
    }
    
    public float dopplerLevel
    {
        set {audioSource.dopplerLevel = value;}
    }

}
