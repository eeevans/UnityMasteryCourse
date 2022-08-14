using UnityEngine;

public static class Collision2DExtensions
{
    public static bool WasHitByPlayer(this Collision2D target)
    {
        return target.collider.TryGetComponent<PlayerMovement>(out PlayerMovement player);
    }

    public static bool WasHitFromSide(this Collision2D target)
    {
        return target.contacts[0].normal.x > 0.5f || target.contacts[0].normal.x < -0.5f;
    }

    public static bool WasHitFromBottom(this Collision2D target)
    {
        return target.contacts[0].normal.y > 0.5f;
    }

    public static bool WasHitFromTop(this Collision2D target)
    {
        return target.contacts[0].normal.y < -0.5f;
    }

}