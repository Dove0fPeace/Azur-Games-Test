using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text m_CountText;

    private int _coinCount;
    public int CoinCount => _coinCount;

    private void Start()
    {
        _coinCount = 0;
        UpdateCountView();
        Coin.OnCoinCollected += IncrementCoinCount;
    }

    private void OnDestroy()
    {
        Coin.OnCoinCollected -= IncrementCoinCount;
    }

    private void IncrementCoinCount()
    {
        _coinCount++;
        UpdateCountView();
    }

    private void UpdateCountView()
    {
        m_CountText.text = _coinCount.ToString();
    }
}
