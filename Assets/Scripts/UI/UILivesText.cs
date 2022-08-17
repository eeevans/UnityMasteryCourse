using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += (lives) => UpdateLives(lives);
        tmp.text = GameManager.Instance.Lives.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= (lives) => UpdateLives(lives);
    }

    private void UpdateLives(int lives)
    {
        tmp.text = lives.ToString();
    }
}
