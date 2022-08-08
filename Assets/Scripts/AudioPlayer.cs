using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;

    [Header("Coin SFX")]
    [SerializeField] private AudioClip m_CoinPickUpSFX;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float m_CoinPickUpSFX_Volume;

    [Header("Level Complete SFX")]
    [SerializeField] private AudioClip m_LevelCompleteSFX;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float m_LevelCompleteSFX_Volume;

    private void OnEnable()
    {
        Coin.OnCoinCollected += () => PLayAudioClip(m_CoinPickUpSFX, m_CoinPickUpSFX_Volume);
        FinishLine.OnLevelComplete += () => PLayAudioClip(m_LevelCompleteSFX, m_LevelCompleteSFX_Volume);
    }

    private void OnDisable()
    {

    }

    public void PLayAudioClip(AudioClip clip, float volume)
    {
        m_AudioSource.PlayOneShot(clip, volume);
    }
}
