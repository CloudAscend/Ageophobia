using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class player_Move : MonoBehaviour
{


    public Transform MousePointPos;
    public Transform CurTarget;
    public Transform Player_Pos;

    [SerializeField]
    private GameObject Player;


    float Move_speed = 1f;

    private bool isMove;

    Rigidbody2D rb;
    

    private void Update()
    {
        GetMousePos();
        Update_Moving();
 
        
    }
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        
    }

    private void GetMousePos()
    {
        MousePointPos.localPosition = Input.mousePosition;

    }

    private void Update_Moving()
    {
        if (Input.GetMouseButtonDown(0) && !isMove)
        {
            
            CurTarget = MousePointPos;
            isMove = true;

            float xMove = CurTarget.position.x;
            float zMove = CurTarget.position.y;
            
            Move_speed = 1f;

            Vector3 Move = new Vector3(xMove, zMove) * Move_speed;
            rb.velocity = Move;
            
        }
        Debug.Log(CurTarget.position);
        if (Vector3.Distance(CurTarget.position, transform.position) <= 1f)
        {
            //Move_speed = 0f;
            Debug.Log(CurTarget.position);
            rb.velocity = Vector2.zero;
            isMove = false;
        }
    }
}