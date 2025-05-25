using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewAudioEvent", menuName = "AudioEvent")]
public class AudioScriptableEvent : ScriptableObject
{
    public UnityEvent<AudioClip> PlaySoundRequest;

    public void Play(AudioClip clip)
    {
        PlaySoundRequest?.Invoke(clip);
    }
}
