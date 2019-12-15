using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipGrab;
    public AudioClip audioClipClick;
    public AudioClip audioClipDamage;
    public AudioClip audioClipBeep;
    public static SoundManager instance;

    private void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }

    public void PlayGrabSound()
    {
        audioSource.PlayOneShot(audioClipGrab);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(audioClipClick);
    }
    public void PlayDamageSound()
    {
        audioSource.PlayOneShot(audioClipDamage);
    }
    public void PlayErrorSound()
    {
        audioSource.PlayOneShot(audioClipBeep);
    }
}
