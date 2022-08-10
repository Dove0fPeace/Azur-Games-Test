using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform m_CharacterTransform;
    [SerializeField] private Transform m_FinishTransform;

    [SerializeField] private Slider m_ProgressBar;

    private void Start()
    {
        m_ProgressBar.value = 0;

        m_ProgressBar.minValue = m_CharacterTransform.position.z;
        m_ProgressBar.maxValue = m_FinishTransform.position.z;
    }

    private void Update()
    {
        m_ProgressBar.value = m_CharacterTransform.position.z;
    }
}
