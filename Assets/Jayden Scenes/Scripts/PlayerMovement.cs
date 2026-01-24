using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 4;
    private SpriteRenderer sp;
    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }
} 
