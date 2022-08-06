using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManager.Instance.OnCoinsChanged += CoinDing;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= CoinDing;
    }

    private void CoinDing(int coins)
    {
        audioSource.Play();
    }
}
