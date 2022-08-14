using System;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] float speed = 0.25f;
    [SerializeField] GameObject _spawnOnStompPrefab;

    Collider2D _collider;
    private const float Small_Distance = 0.1f;
    private const float Negative_Direction = -1f;
    Rigidbody2D _rigidBody;
    private SpriteRenderer _renderer;
    Vector2 _direction = Vector2.left;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.WasHitByPlayer())
        {
            if (target.WasHitFromTop())
            {
                HandleWalkerStomped(target.collider.GetComponent<PlayerMovement>());
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void HandleWalkerStomped(PlayerMovement playerMovement)
    {
        if (_spawnOnStompPrefab != null)
            Instantiate(_spawnOnStompPrefab, transform.position, transform.rotation);
        playerMovement.Bounce();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _direction * speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEdge() || CollideWithNonPlayerObject())
            SwitchDirection();
    }

    private bool CollideWithNonPlayerObject()
    {
        float x = GetForwardX();
        float y = transform.position.y;

        Vector2 origin = new Vector2(x, y);

        var hit = Physics2D.Raycast(origin, _direction, Small_Distance);

        return CollisionWithNonPlayerOrNonCheckpointDetected(hit);
    }

    private static bool CollisionWithNonPlayerOrNonCheckpointDetected(RaycastHit2D hit)
    {
        return !(hit.CollisionNotDetected() || 
            hit.CollidedWithCheckpoint() || 
            hit.CollidedWithPlayer());
    }

    private bool ReachedEdge()
    {
        float x = GetForwardX();
        float y = _collider.bounds.min.y;

        Vector2 origin = new Vector2(x, y);

        var hit = Physics2D.Raycast(origin, Vector2.down, Small_Distance);

        return hit.collider == null;
    }

    private float GetForwardX()
    {
        return _direction.x == Negative_Direction ?
            _collider.bounds.min.x - Small_Distance :
            _collider.bounds.max.x + Small_Distance;
    }

    private void SwitchDirection()
    {
        _direction *= Negative_Direction;
        _renderer.flipX = !_renderer.flipX;
    }
}

public static class RaycastHit2DExtensions
{
    public static bool CollisionNotDetected(this RaycastHit2D hit)
    {
        return hit.collider is null;
    }

    public static bool CollidedWithCheckpoint(this RaycastHit2D hit)
    {
        return hit.collider.isTrigger;
    }

    public static bool CollidedWithPlayer(this RaycastHit2D hit)
    {
        return !(hit.collider.GetComponent<PlayerMovement>() is null);
    }

}

