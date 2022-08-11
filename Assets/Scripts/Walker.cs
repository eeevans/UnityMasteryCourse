using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] float speed = 0.25f;
    Collider2D _collider;
    Rigidbody2D _rigidBody;
    Vector2 direction;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Vector2.right;
        _rigidBody.MovePosition(_rigidBody.position + direction * speed * Time.fixedDeltaTime);
    }
}
