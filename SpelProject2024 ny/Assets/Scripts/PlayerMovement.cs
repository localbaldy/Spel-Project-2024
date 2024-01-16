using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;


    public LayerMask groundLayer;
    private bool isFacingRight = true;

    private Rigidbody2D rb;
    //private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }
    private void Update()
    {

        float moveDirection = Input.GetAxis("Horizontal");
        Move(moveDirection);
        if (moveDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            Flip();
        }

    }
    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
        float absoluteSpeed = Mathf.Abs(direction * moveSpeed);
        //animator.SetFloat("Speed", absoluteSpeed);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
        Transform firepoint = transform.Find("FirePoint");
        firepoint.localPosition = new Vector3(-firepoint.localPosition.x, firepoint.localPosition.y,
        firepoint.localPosition.z);
    }


}