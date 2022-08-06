using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Passed { get; private set; }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.TryGetComponent<PlayerMovement>(out PlayerMovement player))
            Passed = true;
    }
}
