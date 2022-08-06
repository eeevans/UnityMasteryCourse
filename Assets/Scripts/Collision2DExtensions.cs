using UnityEngine;

public static class Collision2DExtensions
{
    public static bool CollidedWithPlayer(this Collision2D target)
    {
        return target.collider.TryGetComponent<PlayerMovement>(out PlayerMovement player);
    }

    public static bool WasHitFromBottom(this Collision2D target)
    {
        return target.contacts[0].normal.y > 0.5f;
    }

}