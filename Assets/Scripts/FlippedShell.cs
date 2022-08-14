using UnityEngine;

public class FlippedShell : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    Vector2 _direction;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, _rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.WasHitByPlayer())
        {
            HandleCollisionWithPlayer(target);
        }
        else if (target.WasHitFromSide())
        {
            LaunchShell(target);
            var takeShellHits = target.collider.GetComponent<ITakeShellHits>();
            if (takeShellHits != null)
                takeShellHits.HandleShellHit(this);
        }
    }

    private void HandleCollisionWithPlayer(Collision2D target)
    {
        var playerMovement = target.collider.GetComponent<PlayerMovement>();
        if (_direction.magnitude == 0)
        {
            LaunchShell(target);

            if (target.WasHitFromTop())
                playerMovement.Bounce();
        }
        else
        {
            if (target.WasHitFromTop())
            {
                _direction = Vector2.zero;
                playerMovement.Bounce();
            }
            else
                GameManager.Instance.KillPlayer();
        }
    }

    private void LaunchShell(Collision2D collision)
    {
        float floatDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;
        _direction = new Vector2(floatDirection, 0);
    }
}
