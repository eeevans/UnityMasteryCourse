using UnityEngine;

public class Walker : MonoBehaviour
{
    private const float Small_Distance = 0.1f;
    private const float Negative_Direction = -1f;
    [SerializeField] float speed = 0.25f;
    Collider2D _collider;
    Rigidbody2D _rigidBody;
    private SpriteRenderer _renderer;
    Vector2 _direction = Vector2.left;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _direction * speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEdge())
            SwitchDirection();
    }

    private bool ReachedEdge()
    {
        float x = _direction.x == Negative_Direction ?  
            _collider.bounds.min.x - Small_Distance : 
            _collider.bounds.max.x + Small_Distance;
        float y = _collider.bounds.min.y;

        Vector2 origin = new Vector2(x, y);

        var hit = Physics2D.Raycast(origin, Vector2.down, Small_Distance);
        
        return hit.collider == null;
    }

    private void SwitchDirection()
    {
        _direction *= Negative_Direction;
        _renderer.flipX = !_renderer.flipX;
    }
}
