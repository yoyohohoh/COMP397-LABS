using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio Manager is scene dependent. Which means that it will control the audios
/// for a specific scene.
/// </summary>
public class AudioManager : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;
    [SerializeField] private List<AudioAsset> audios = new List<AudioAsset>();
    [SerializeField] private string _musicName;

    void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerSubject =  player.GetComponent<Subject>();
        }
    }

    void Start()
    {
        var musicAsset = audios.Find(a => a.AudioName == _musicName);
        AudioController.Instance.PlayMusic(musicAsset);
    }
    void OnEnable()
    {
        if (_playerSubject == null) { return; }
        _playerSubject.AddObserver(this);
    }

    void OnDisable()
    {
        if (_playerSubject == null) { return; }
        _playerSubject.RemoveObserver(this);
    }

    public void OnNotify(PlayerEnums playerEnums)
    {
        AudioAsset asset = null;
        switch (playerEnums)
        {
            case PlayerEnums.Jump:
                asset =
                    audios.Find(s => s.AudioName == "Jump");
                AudioController.Instance.PlaySfx(asset);
                break;
            case PlayerEnums.Died:
                asset =
                  audios.Find(s => s.AudioName == "Die");
                AudioController.Instance.PlaySfx(asset);
                break;
            default:
                break;
        }
    }
}