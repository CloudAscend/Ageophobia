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
        // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ�Ͽ� MousePointPos�� ��ġ�� �����մϴ�.
        Vector3 MousePointPos = Input.mousePosition;
        MousePointPos.z = 0f; // ���� ��ǥ�� z���� 0���� �����մϴ�.
        
    }

    private void UpdateMoving()
    {
        if (Input.GetMouseButtonDown(0) && !isMove)
        {
            GetMousePos();
            Debug.Log(CurTarget.position);

            // ���콺 Ŭ�� ��ġ�� �̵� ��ǥ�� �����մϴ�.
            CurTarget = MousePointPos;
            isMove = true;

            // �÷��̾��� ���� ��ġ�� �̵� ��ǥ ��ġ ������ ������ ���մϴ�.
            Vector2 direction = (CurTarget.position - Player.transform.position).normalized;
            // ���� �������� �̵��մϴ�.
            rb.velocity = direction * Move_speed;
        }

        // �÷��̾�� �̵� ��ǥ ��ġ ������ �Ÿ��� ���� �� ���ϸ� �̵��� ����ϴ�.
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
