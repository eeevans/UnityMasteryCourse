using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.WasHitFromBottom() && target.CollidedWithPlayer())
        {
            Destroy(gameObject);
        }
    }

}
