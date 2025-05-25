using UnityEngine;

namespace WhackAThem.GameLogics.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        AudioSource audioSource;

        [SerializeField]
        AudioScriptableEvent m_SoundEffectChannel;
    }
}