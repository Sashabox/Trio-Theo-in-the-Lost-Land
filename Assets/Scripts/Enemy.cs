using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rb;
    private bool forward;
    private SpriteRenderer sprite;

    private Vector2 velo;

    void Start()
    {
        forward = true;
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velo = rb.velocity;

        if (forward)
            velo = transform.right * Speed;
        else
           velo = transform.right * Speed;

        velo.y = rb.velocity.y;
        rb.velocity = velo;

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyWall"))
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
