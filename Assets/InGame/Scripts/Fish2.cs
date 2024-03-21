using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish2 : ItemBase
{
    public Transform target;
    public float moveSpeed;

    private Vector2 moveVec;
    private bool isMove;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRend;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        target = Player.instance.transform;
    }

    protected override void GetItem()
    {
        Player.instance.moveSpeed += 2;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        isMove = Vector2.Distance(target.position, transform.position) < 5f;

        if (isMove)
        {
            Move();
            Look();
        }
    }

    private void Move()
    {
        moveVec.x = transform.position.x - target.position.x;
        moveVec.y = transform.position.y - target.position.y;
        moveVec = moveVec.normalized;

        rigidbody.velocity = moveVec * moveSpeed;
    }

    private void Look()
    {
        if (moveVec.magnitude > 0)
            spriteRend.flipX = moveVec.x > 0;
    }
}
