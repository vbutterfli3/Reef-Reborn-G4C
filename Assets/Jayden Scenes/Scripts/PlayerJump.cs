using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    // Forces
    public float JumpForce = 5f;
    public float WaterJumpForce = 500f;
    public float FallForce = 5;
    private Vector2 GravityVector;

    // Capsule
    public float CapsuleHeight = 0.25f;
        public float CapsuleRadius = 0.08f;

    // Ground Check
    public Transform FeetCollider;
    public LayerMask GroundMask;
    private bool GroundCheck;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     // Checks if player is touching ground
        GroundCheck = Physics2D.OverlapCapsule(FeetCollider.position, new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, GroundMask);

     // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && (GroundCheck || playerMovement.isInWater))
        {
            if (playerMovement.isInWater)
            {
                rb.velocity = new Vector2(rb.velocity.x, WaterJumpForce);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
        }

     // Falling
        if (rb.velocity.x < 0 && !playerMovement.isInWater)
        {
            rb.velocity += GravityVector * (FallForce * Time.deltaTime);
        }

        if(rb.velocity.y < -20)
        {
            rb.velocity = new Vector2(rb.velocity.x, -20);
        }
    }
}

