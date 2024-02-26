using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioData
{
    public string audioName;
    public AudioClip audioClip;
}

public class _OLDAudioManager : MonoBehaviour// , IObserver
{
    //[SerializeField] private Subject _playerSubject;
    //[SerializeField] private List<AudioData> audios = new List<AudioData>();
    //[SerializeField] private AudioSource _sfxPlayer;
    //void Awake()
    //{
    //    _playerSubject = GameObject.FindGameObjectWithTag("Player").GetComponent<Subject>();

    //}

    //void OnEnable()
    //{
    //    _playerSubject.AddObserver(this);
    //}

    //void OnDisable()
    //{
    //    _playerSubject.RemoveObserver(this);
    //}

    //public void OnNotify(PlayerEnums playerEnums)
    //{
    //    switch(playerEnums)
    //    {
    //        case PlayerEnums.Jump:
    //            _sfxPlayer.clip = audios.Find(s => s.audioName == "Jump").audioClip;//find the audio file
    //            _sfxPlayer.Play();//play the sound
    //            break;
    //        case PlayerEnums.Died:
    //            _sfxPlayer.clip = audios.Find(s => s.audioName == "Died").audioClip;
    //            _sfxPlayer.Play();
    //            break;  
    //        default:
    //            break;
    //    }
    //}
}
