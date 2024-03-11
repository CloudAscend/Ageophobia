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
            if (player.transform.position.y > seaHeight) //����
            {
                GameManager.instance.player.isGrounded = true;
            }
            else if (player.transform.position.y > skyHeight) //�ϴ�
            {

            }
            else //�ٴ� 
            {
                GameManager.instance.player.isGrounded = false;
            }
        }
    }
}
