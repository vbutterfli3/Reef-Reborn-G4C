using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 4;
    public int pullForce = -100; 
    private SpriteRenderer sp;
    Animator animator;
    bool isInWater = false;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float xInput = 0;
        if ( isInWater )
        {
            xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(xInput * speed, yInput);
        }
        else
        {
            xInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        }


        animator.SetFloat("Speed", Mathf.Abs(xInput));

        if (xInput > 0) //if moving and facing right
        {
            animator.SetBool("FacingRight", true);
        }
        else if (xInput < 0)
        {
            animator.SetBool("FacingRight", false);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            animator.Play("idleSwim");
            StartCoroutine(PullHer());
            isInWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")

        {
            animator.Play("idlebreathing");
            rb.gravityScale = 1;
            isInWater = false;
        }
    }

    private IEnumerator PullHer()
    {
        rb.gravityScale = 20;
        yield return new WaitForSeconds(0.5f);
        rb.gravityScale = 0;
    }
}