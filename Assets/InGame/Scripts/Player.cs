using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 moveVec;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRend;
    private Animator anim;

    public bool isMove;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        isMove = true;
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            PlayerMove();
            PlayerLook();
        }
    }

    private void PlayerMove()
    {
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.y = Input.GetAxis("Vertical");

        rigidbody.velocity = moveVec * moveSpeed;
    }

    private void PlayerLook()
    {
        if (moveVec.x != 0)
            spriteRend.flipX = moveVec.x > 0;

        anim.SetBool("Walk", moveVec.magnitude > 0);
    }
}
