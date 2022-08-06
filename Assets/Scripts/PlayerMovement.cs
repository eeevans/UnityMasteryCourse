using UnityEngine;

[RequireComponent(typeof(IGround))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMove
{
    [SerializeField] float moveSpeed = 2;
    [SerializeField] private float jumpForce = 100;
    Rigidbody2D rb = null;

    IGround characterGrounding;
    private bool isJumping;
    private bool fire;
    private float horizontal;

    public float Speed { get; private set; }
    public float Direction { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<IGround>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        Direction = horizontal;
        Speed = Mathf.Abs(horizontal);

        Vector3 movement = new Vector3(horizontal, 0);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    private void HandleJump()
    {
        var isGrounded = characterGrounding.IsGrounded;
        isJumping = !isGrounded;
        fire = Input.GetKey(KeyCode.Space);
        if (CanJump(isGrounded))
        {
            PlayerJump();
        }
    }

    private bool CanJump(bool isGrounded)
    {
        return fire && isGrounded && !isJumping;
    }

    private void PlayerJump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce);
    }

}
