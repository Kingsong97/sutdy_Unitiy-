using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 7;
    public GameObject target;
    Vector3 dir;
    public GameObject exploPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 0 ~ 9 사이의 값을 랜덤하게 뽑자
        int rand = Random.Range(0, 10);
        // 만약에 랜덤값이 3보다 작으면 (30%)
        if (rand < 4)
        {
            // 방향을 아래로!
            dir = Vector3.down;
        }
        // 그렇지 않으면
        else
        {
            // 플레이어(타겟)를 찾기
            target = GameObject.Find("Player");
            // 플레이어가 없다면
            if(target == null)
            {
                dir = Vector3.down;
            }
            else { 
            // 방향을 타겟을 향하게
            // Target을 향하는 방향 구하기 (Enemy ---> Player)
            dir = target.transform.position - transform.position;
            // 정규화
            dir.Normalize();
            }
        }
        
    }

    // 최초에 한번만 타겟을 향하는 방향을 구하자.
    // 그 방향으로 계속 움직이자.

    // Update is called once per frame
    void Update()
    {
        // 아래로 이동
        // transform.position += Vector3.down * speed * Time.deltaTime;
        // 구한 방향으로 이동
        transform.position += dir * speed * Time.deltaTime;
    }

    //other : 부딫힌 객체의 정보가 들어옴
    private void OnTriggerEnter(Collider other)
    {

        /* int layer = LayerMask.NameToLayer("DestroyZone");
        if (other.gameObject.layer == LayerMask.NameToLayer("DestroyZone"))
        {

        } */

       //  만약 부딫힌 물체가 DestroyZone 이라면 무시
        if (other.name.Contains("DestroyZone") == false)
        {
            // 부딪힌 GameObject 파괴
            Destroy(other.gameObject);

       
            // 폭발효과 Prefab 을 하나 복제하자.
            GameObject explo = Instantiate(exploPrefab);
            // 폭발 위치를 나의 위치한다
            explo.transform.position = transform.position;  
            // 만들어진 효과에서 ParticleSystem 컴포넌트 가져오자.
            ParticleSystem ps = explo.GetComponent<ParticleSystem>();
            // 가져온 컴포넌트의 Play 함수 실행
            ps.Play();
            // 만들어진 효과 3초뒤 파괴
            Destroy(explo, 3);
        } 

        // 나도 파괴
        Destroy(gameObject);



        /*if (other.name.Equals("DestroyZone") == true)
        {
            // 부딪힌 GameObject 파괴
            Destroy(other.gameObject);

        } */


    }
}
