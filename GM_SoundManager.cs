using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_SoundManager : MonoBehaviour
{

    static GM_SoundManager _instance = null;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioSource[] aSources;

    public bool Mute;


    // Use this for initialization
    void Start()
    {
        if (instance)
            Destroy(gameObject);
        else
        {
            instance = this;

            DontDestroyOnLoad(this);
        }
    }

    public void playSingleSound(AudioClip clip, float volume = 1.0f)
    {
        if (sfxSource)
        {
            sfxSource.clip = clip;

            sfxSource.volume = volume;

            sfxSource.Play();
        }
    }

    public static GM_SoundManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }
    
}
