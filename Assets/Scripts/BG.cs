using UnityEngine;

public class BG : MonoBehaviour
{
    public float speed = 3; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 아래로 움직이자.
        transform.position += Vector3.down * speed * Time.deltaTime; 

        // 만약에 위치y 값이 -30 보다 작으면
        if(transform.position.y < -30)
        {
        // 위치를 위로 90 만큼 이동시키자
            transform.position += Vector3.up * 90;
        }
    }
}
