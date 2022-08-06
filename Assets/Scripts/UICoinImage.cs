using System;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsChanged += PulseCoin;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PulseCoin;
    }

    private void PulseCoin(int coins)
    {
        animator.SetTrigger("Pulse");
    }
}
