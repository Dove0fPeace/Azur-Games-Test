using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowingCamera : MonoBehaviour
{
    [SerializeField] private Vector3 m_Offset;

    [SerializeField] private Transform m_TargetTransform;

    private void Update()
    {
        transform.position = new Vector3(0, m_TargetTransform.position.y + m_Offset.y, m_TargetTransform.position.z + m_Offset.z);

    }
}
