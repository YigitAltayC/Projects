using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameSFX
{
    PlayerFlySFX = 0,
    PlayerDeathSFX = 1,
    PickupSFX = 2,
    WinSFX = 3
}

public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioClip[] musicSounds;
    public AudioClip[] soundEffects;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;


    // Start is called before the first frame update
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(string musicName)
    {
        AudioClip clip = Array.Find(musicSounds, audioClip => audioClip.name.Equals(musicName));
        /*_musicSource.clip = clip;
        _musicSource.loop = true;
        _musicSource.Play();*/

    }
    

    public void PlaySound(GameSFX gameSfx)
    {
        //_soundSource.clip = soundEffects[(int) gameSfx];
        _soundSource.Stop();
        _soundSource.PlayOneShot(soundEffects[(int) gameSfx]);
    }

    public bool IsSoundPlaying(GameSFX gameSfx)
    {
        return _soundSource.isPlaying;
    }

    public void StopSound()
    {
        _soundSource.Stop();
    }

    
}
