using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static event Action OnLevelComplete;

    [SerializeField] private GameObject m_FinishUI;
    [SerializeField] private AudioSource m_AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        OnLevelComplete?.Invoke();
        m_AudioSource.Play();
        m_FinishUI.SetActive(true);
    }
}
