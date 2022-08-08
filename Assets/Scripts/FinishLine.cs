using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static event Action OnLevelComplete;

    [SerializeField] private GameObject m_FinishUI;

    private void OnTriggerEnter(Collider other)
    {
        OnLevelComplete?.Invoke();

        m_FinishUI.SetActive(true);
    }
}
