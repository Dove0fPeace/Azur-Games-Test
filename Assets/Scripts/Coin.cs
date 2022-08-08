using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnCoinCollected;

    [SerializeField] private float m_RotateSpeed;

    [SerializeField] private GameObject m_PickupFX;

    private void Update()
    {
        transform.Rotate(new Vector3 (0, m_RotateSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(m_PickupFX, transform.position, Quaternion.identity);
        OnCoinCollected?.Invoke();
        Destroy(gameObject);
    }
}
