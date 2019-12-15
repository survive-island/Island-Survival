using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip audioClipGrab; //물건 집을 때
    public AudioClip audioClipClick; //인벤토리 클릭할 때
    public AudioClip audioClipDamage; //Hp 줄을 때
    public AudioClip audioClipBeep; //에러 뜰 때
    public AudioClip audioClipButton; //버튼 클릭할 때

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
    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(audioClipButton);
    }
}
