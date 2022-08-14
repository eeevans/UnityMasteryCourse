using UnityEngine;

public interface IGround
{
    bool IsGrounded { get; }
    Vector2 GroundedDirection { get; }
}