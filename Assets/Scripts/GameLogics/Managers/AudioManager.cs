using UnityEngine;

namespace WhackAThem.GameLogics.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource m_MusicAudioSource;

        [SerializeField]
        AudioScriptableEvent m_MusicChannel;

        [SerializeField]
        private AudioSource m_SoundEffectAudioSourceObject;

        [SerializeField]
        AudioScriptableEvent m_SoundEffectChannel;

        private void Start()
        {
            m_SoundEffectChannel.PlaySoundRequest += PlaySoundEffect;
            m_MusicChannel.PlaySoundRequest += PlayMusic;
        }

        private void PlayMusic(AudioClip clip)
        {
            m_MusicAudioSource.clip = clip;
            m_MusicAudioSource.Play();
        }

        private void PlaySoundEffect(AudioClip clip)
        {
            var source = Instantiate(m_SoundEffectAudioSourceObject);
            source.clip = clip;
            source.PlayOneShot(clip);
            Destroy(source.gameObject, clip.length);
        }
    }
}