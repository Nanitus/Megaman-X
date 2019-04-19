using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_VolumeSlider : MonoBehaviour {

    private AudioSource Audiosource;

    private float Volume = 1f;

    private void Start() {
        Audiosource = GetComponent<AudioSource>();
    }

    private void Update() {
        Audiosource.volume = Volume;
    }
    
    public void SetVolume(float vol)
    {
        Volume = vol;
    }

    public void MuteVolume(bool vol)
    {
        Volume = 0f;
    }
}
