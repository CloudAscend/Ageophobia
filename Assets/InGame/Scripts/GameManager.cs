using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player;
    public Joystick joystick;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }

    private void CheckGround()
    {
        if (player.transform.position.y > 5) //Áö»ó
            player.moveState = PlayerController.MoveState.onGround;
    }
}
