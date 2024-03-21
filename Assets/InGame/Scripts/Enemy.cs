using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    private Vector2 moveVec;
    private Rigidbody2D rigidbody;
    private bool isMove;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isMove)
            Move();
    }

    private void Move()
    {
        moveVec.x = target.position.x - transform.position.x;
        moveVec.y = target.position.y - transform.position.y;
        moveVec = moveVec.normalized;

        rigidbody.velocity = moveVec * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) isMove = true;
    }
}
