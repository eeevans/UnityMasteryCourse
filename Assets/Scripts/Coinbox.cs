using UnityEngine;

public class Coinbox : MonoBehaviour, ITakeShellHits
{
    [SerializeField] SpriteRenderer enabledSprite;
    [SerializeField] SpriteRenderer disabledSprite;
    [SerializeField] Sprite disabledSpriteImage;
    [SerializeField] int totalCoins = 1;
    [SerializeField] int remainingCoins;

    Animator animator;

    private Vector2 BOTTOM = new Vector2(0, 1);

    public void HandleShellHit(FlippedShell flippedShell)
    {
        if (remainingCoins > 0)
            TakeCoin();
    }

    private void Awake()
    {
        remainingCoins = totalCoins;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (remainingCoins > 0 && target.WasHitFromBottom() && target.WasHitByPlayer())
        {
            TakeCoin();
        }
    }

    private void TakeCoin()
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
