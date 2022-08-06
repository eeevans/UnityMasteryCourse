using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.TryGetComponent<PlayerMovement>(out PlayerMovement targetMovment))
            GameManager.Instance.KillPlayer();
    }
}
