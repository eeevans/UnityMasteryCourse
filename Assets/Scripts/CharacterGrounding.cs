using UnityEngine;

public class CharacterGrounding : MonoBehaviour, IGround
{
    [SerializeField] Transform leftFoot;
    [SerializeField] Transform rightFoot;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;

    private void Update()
    {
        CheckFootForGrounding(leftFoot);
        if (!IsGrounded)
            CheckFootForGrounding(rightFoot);

        StickToMovingObjects();
    }

    private void StickToMovingObjects()
    {
        if (!(groundedObject is null))
        {
            if (groundedObjectLastPosition.HasValue &&
                groundedObjectLastPosition.Value != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;
                transform.position += delta;
            }

            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);
        IsGrounded = !(raycastHit.collider is null);
        groundedObject = raycastHit.collider?.transform;
    }
}
