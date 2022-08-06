using System;
using UnityEngine;

public class Coinbox : MonoBehaviour
{
    [SerializeField] SpriteRenderer enabledSprite;
    [SerializeField] SpriteRenderer disabledSprite;
    [SerializeField] Sprite disabledSpriteImage;
    [SerializeField] int totalCoins = 1;
    [SerializeField] int remainingCoins;

    Animator animator;

    private Vector2 BOTTOM = new Vector2(0, 1);

    private void Awake()
    {
        remainingCoins = totalCoins;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (remainingCoins > 0 && target.WasHitFromBottom() && target.CollidedWithPlayer())
        {
            GameManager.Instance.AddCoin();
            remainingCoins--;
            animator.SetTrigger("FlipCoin");
            if (remainingCoins <= 0)
            {
                enabledSprite.enabled = false;
                disabledSprite.enabled = true;
            }
        }
    }
}
