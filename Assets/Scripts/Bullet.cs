using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 총 소리를 내자 !
        // AudioSource 컴포넌트 가져오자.
        AudioSource audio = GetComponent<AudioSource>();
        // 가져온 컴포넌트에서 Play 함수 실행
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

  
}
