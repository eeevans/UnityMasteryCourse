using UnityEngine;

public class CharacterGrounding : MonoBehaviour, IGround
{
    [SerializeField] Transform[] _positions;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }
    public Vector2 GroundedDirection { get; private set; }

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;

    private void Update()
    {
        foreach (var position in _positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded)
                break;
        }

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
        var raycastHit = Physics2D.Raycast(foot.position, foot.forward, maxDistance, layerMask);
        IsGrounded = !(raycastHit.collider is null);
        GroundedDirection = raycastHit.collider != null ? foot.forward : Vector3.zero;

        if (GroundedOnNewObject(raycastHit.collider?.transform))
            RememberNewObject(raycastHit.collider.transform);

        groundedObject = raycastHit.collider?.transform;

    }

    private void RememberNewObject(Transform transform)
    {
        groundedObjectLastPosition = transform.position;
    }

    private bool GroundedOnNewObject(Transform item)
    {
        return IsGrounded && groundedObject != item;
    }
}
