using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveDistance = 2f; // how far it goes from where i put the prefab
    public float speed = 1.5f;

    [Header("Bobbing")]
    public float bobHeight = 0.25f;
    public float bobSpeed = 2f;

    [Header("Sprite")]
    public Transform sprite;

    private float startX;
    private float startY;
    private bool movingRight = true;
    private float timeOffset;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        timeOffset = Random.Range(0f, 10f); 
    }

    void Update()
    {
        Move(); //moving randomly back and forth 
        Bob(); //when it bounces up and down
    }

    void Move()
    {
        float dir = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * dir * speed * Time.deltaTime);

        if (transform.position.x >= startX + moveDistance)
        {
            movingRight = false;
            sprite.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x <= startX - moveDistance)
        {
            movingRight = true;
            sprite.localScale = new Vector3(1, 1, 1);
        }
    }

    void Bob()
    {
        float y = startY + Mathf.Sin((Time.time + timeOffset) * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    void Flip() //to flip the sprite when it makes its way back
    {
        Vector3 scale = sprite.localScale;
        scale.x = Mathf.Abs(scale.x) * (movingRight ? 1 : -1);
        sprite.localScale = scale;
    }
}
