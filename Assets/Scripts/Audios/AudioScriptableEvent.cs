using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioEvent", menuName = "AudioEvent")]
public class AudioScriptableEvent : ScriptableObject
{
    public event Action<AudioClip> PlaySoundRequest;

    public void Play(AudioClip clip)
    {
        PlaySoundRequest?.Invoke(clip);
    }
}
