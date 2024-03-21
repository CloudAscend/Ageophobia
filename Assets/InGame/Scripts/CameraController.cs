using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float maxDistance = 0.1f;

    private Vector2 moveVec;
    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(target.position, transform.position) < maxDistance)
            return;

        moveVec.x = target.position.x - transform.position.x;
        moveVec.y = target.position.y - transform.position.y;

        transform.Translate(moveVec * moveSpeed * Time.deltaTime);
    }
}
