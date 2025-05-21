using UnityEngine;

// 클래스 이름 = 대문자 시작
// 함수 이름 = 대문자 시작
// 변수 = 소문자 시작

public class Player : MonoBehaviour
{
    // 이동 속력
    public float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자의 입력 받아오기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 입력 받은 값으로 방향 설정
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.up * v;
        Vector3 dir = dirH + dirV;
        // dir의 크기를 1로 만들자 (정규화, Normalize)
        dir.Normalize();
        // 해당 방향으로 계속 이동


        // 해당방향이동
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

        CheckRange();
    }

    void CheckRange()
    {
        // 만약 ViewPort 좌표 x값이 0보다 작으면
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.left * 0.5f);
        if (viewportPoint.x < 0)
        {
            viewportPoint.x = 0;
            // 나의 위치 x 값을 Viewport x 의 값을 3D 좌표로 변환
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.right * 0.5f;
        }
        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.right * 0.5f);
        if (viewportPoint.x >= 1)
        {
            viewportPoint.x = 1;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.left * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.up * 0.5f);
        if (viewportPoint.y >= 1)
        {
            viewportPoint.y = 1;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.down * 0.5f;
        }

        viewportPoint = Camera.main.WorldToViewportPoint(transform.position + Vector3.down * 0.5f);
        if (viewportPoint.y < 0)
        {
            viewportPoint.y = 0;
            Vector3 pos = Camera.main.ViewportToWorldPoint(viewportPoint);
            transform.position = pos + Vector3.up * 0.5f;
        }
        // 나의 좌표를 해상도 좌표계로 (해상도 범위)
        //print(Camera.main.WorldToScreenPoint(transform.position));
        // 나의 좌표를 카메라 좌표계로 (0~1로 표현)
        //print(Camera.main.WorldToViewportPoint(transform.position));
    }
}
