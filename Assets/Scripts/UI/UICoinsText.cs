using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI coinsText;

    private void Awake()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += (coins) => UpdateCoins(coins);
        coinsText.text = GameManager.Instance.Coins.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= (coins) => UpdateCoins(coins);
    }

    private void UpdateCoins(int coins)
    {
        coinsText.text = coins.ToString();
    }
}
