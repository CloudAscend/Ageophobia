using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGames : MonoBehaviour
{
    [SerializeField] private float seaHeight;
    [SerializeField] private float skyHeight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.CompareTag("Player"))
        {
            if (player.transform.position.y > seaHeight) //지상
            {
                GameManager.instance.player.isGrounded = true;
            }
            else if (player.transform.position.y > skyHeight) //하늘
            {

            }
            else //바다 
            {
                GameManager.instance.player.isGrounded = false;
            }
        }
    }
}
