using UnityEngine;

public class CharacterGrounding : MonoBehaviour, IGround
{
    [SerializeField] Transform leftFoot;
    [SerializeField] Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        CheckFootForGrounding(leftFoot);
        if (!IsGrounded)
            CheckFootForGrounding(rightFoot);
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        IsGrounded = !(raycastHit.collider is null);
    }
}
