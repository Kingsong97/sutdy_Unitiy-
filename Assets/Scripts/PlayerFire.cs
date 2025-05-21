using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알 Prefab
    public GameObject bulletPrefab;
    // 총구
    public GameObject firePos;
    public GameObject firePos2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 시
        if (Input.GetButtonDown("Fire1"))
        {
            // 총알공장(Prefab)에서 총알 하나 생성
            GameObject bullet = Instantiate(bulletPrefab);
            GameObject bullet2 = Instantiate(bulletPrefab);
            // 생성된 총알을 총구에 위치
            bullet.transform.position = firePos.transform.position;
            bullet2.transform.position = firePos2.transform.position;
        }

    }
}
