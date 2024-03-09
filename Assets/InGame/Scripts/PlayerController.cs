using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private float sensitive = 0.5f;

    private enum MoveState { inWater, onGround, inAir }

    private MoveState moveState;

    private Rigidbody2D rigidbody;

    private Joystick joystick;

    private Vector2 input;

    private bool isGrounded;


    private SpriteRenderer spriteRend;

    private void Start()
    {
        joystick = GameManager.instance.joystick;

        rigidbody = GetComponent<Rigidbody2D>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input.magnitude >= sensitive)
            SpriteRotate();

        if (isGrounded)
            input = new Vector2(input.x, rigidbody.velocity.y);

        rigidbody.velocity = input * moveSpeed;
    }    

    private void SpriteRotate()
    {
        float dir = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

        Debug.Log(anim.transform.rotation.z * 100);

        spriteRend.flipX = Mathf.Abs(anim.transform.rotation.z * 100) > 90f == true;

        anim.transform.rotation = Quaternion.Slerp(anim.transform.rotation, Quaternion.Euler(0, 0, dir + 180f), 0.1f);
        //anim.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(anim.transform.rotation.z, dir - 90f, 0.01f));
    }
}
