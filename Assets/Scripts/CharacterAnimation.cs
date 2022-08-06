using UnityEngine;
[RequireComponent(typeof(IMove))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    IMove playerMovement;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<IMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var speed = playerMovement.Speed;
        //Debug.Log(playerMovement.Direction);
        animator.SetFloat("Speed", speed);
        if (playerMovement.Direction != 0.0f)
        {
            spriteRenderer.flipX = playerMovement.Direction > 0.0f;
        }
    }
}
