using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    private AudioSource audioSrc;
    public AudioSource Background;
    public AudioSource[] otherSounds;

    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetBackgroundVol(float vol)
    {
        Background.volume = vol;
    }

    public void SetOtherVols(float vol)
    {
        foreach (var sound in otherSounds)
        {
            sound.volume = vol;
        }
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    public void MuteSound()
    {
        musicVolume = 0.001f;
    }
    public void unMuteSound()
    {
        musicVolume = 1f;
    }
}
