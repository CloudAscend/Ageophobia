using UnityEngine;

public class player_Move : MonoBehaviour
{
    public Transform MousePointPos;
    public Transform CurTarget;
    public GameObject Player;
    public float Move_speed = 1f;

    private bool isMove;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Update_MousePosition();
        UpdateMoving();
        
    }

    private void GetMousePos()
    {
        // 스크린 좌표를 월드 좌표로 변환하여 MousePointPos의 위치에 설정합니다.
        Vector3 MousePointPos = Input.mousePosition;
        MousePointPos.z = 0f; // 월드 좌표의 z값을 0으로 고정합니다.
        
    }

    private void UpdateMoving()
    {
        if (Input.GetMouseButtonDown(0) && !isMove)
        {
            GetMousePos();
            Debug.Log(CurTarget.position);

            // 마우스 클릭 위치를 이동 목표로 설정합니다.
            CurTarget = MousePointPos;
            isMove = true;

            // 플레이어의 현재 위치와 이동 목표 위치 사이의 방향을 구합니다.
            Vector2 direction = (CurTarget.position - Player.transform.position).normalized;
            // 구한 방향으로 이동합니다.
            rb.velocity = direction * Move_speed;
        }

        // 플레이어와 이동 목표 위치 사이의 거리가 일정 값 이하면 이동을 멈춥니다.
        if (Vector2.Distance(CurTarget.position, Player.transform.position) <= 0.1f)
        {
            rb.velocity = Vector2.zero;
            isMove = false;
            CurTarget = MousePointPos;
        }
    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        MousePointPos.position = mousePos;
        float w = MousePointPos.position.x;
        float h = MousePointPos.position.y;
        MousePointPos.position = MousePointPos.position + (new Vector3(w, h) * 0.5f);
    }
}
