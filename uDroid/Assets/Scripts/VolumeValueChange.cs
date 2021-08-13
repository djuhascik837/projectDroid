using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    public AudioSource Background;
    public AudioSource[] otherSounds;

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
        Background.volume = vol;
    }

    public void MuteSound()
    {
        Background.volume = 0.001f;
    }
    public void unMuteSound()
    {
        Background.volume = 1f;
    }
}
