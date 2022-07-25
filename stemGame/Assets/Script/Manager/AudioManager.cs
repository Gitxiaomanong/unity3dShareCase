using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instace;

    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

        if (Instace == null)
        {
            Instace = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //播放声音
    public void playAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
