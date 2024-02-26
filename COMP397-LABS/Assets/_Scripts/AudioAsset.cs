using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Audio Asset")]
public class AudioAsset : ScriptableObject
{
    public string AudioName;
    public AudioClip AudioFile;
    public bool IsLooping = false;
}