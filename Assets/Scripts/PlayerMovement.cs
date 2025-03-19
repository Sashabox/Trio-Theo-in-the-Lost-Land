using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform GroundPoint;
    public float MovementSpeed = 1.0f;
    public float JumpForce = 1.0f;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;

    float horizontalMove = 0.0f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool grounded;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = false;

        horizontalMove = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, horizontalMove))
            transform.rotation = horizontalMove < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        Collider2D groundColl = Physics2D.OverlapCircle(GroundPoint.position, GroundCheckRadius, WhatIsGround);
        if (groundColl != null)
        {
            grounded = true;
            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }

        CheckAnimation();
    }

    private void CheckAnimation()
    {
        _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        _animator.SetBool("Grounded", grounded);
        _animator.SetFloat("MoveY", _rigidbody.velocity.y);

        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool("isAttacking", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }

    }

    public void Fire()
    {
        _animator.SetBool("isAttacking", false);
    }
}
