using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMo : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    
    private float dirX = 0f;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float jumpForce;
    private enum MovementState{ idle, running, jumping, falling }
    private MovementState state = MovementState.idle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown( "Jump") && IsGroundnd())
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
           state = MovementState.falling;
        }
        
        anim.SetInteger("state",(int)state);
    }

    private bool IsGroundnd()
    {
        var bounds = coll.bounds;
        return Physics2D.BoxCast(origin: bounds.center, bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
