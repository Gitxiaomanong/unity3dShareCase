using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerS : MonoBehaviour
{
    public static AudioManagerS Instance;

    public AudioSource audioSource;

    void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }


    //播放声音
    public void playAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    //播放声音
    public void pauseAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


}
