using UnityEngine;

public class BreakableBox : MonoBehaviour, ITakeShellHits
{
    public void HandleShellHit(FlippedShell flippedShell)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.WasHitFromBottom() && target.WasHitByPlayer())
        {
            Destroy(gameObject);
        }
    }

}
