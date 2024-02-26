using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : PersistentSingleton<AudioController>
{
    [SerializeField] private AudioSource _sfxPlayer;
    [SerializeField] private AudioSource _musicPlayer;

    public void PlaySfx(AudioAsset asset)
    {
        _sfxPlayer.PlayOneShot(asset.AudioFile);
    }
    public void PlayMusic(AudioAsset asset)
    {
        _musicPlayer.loop = asset.IsLooping;
        _musicPlayer.clip = asset.AudioFile;
        _musicPlayer.Play();
    }
}