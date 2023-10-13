using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour
{
    // 총알의 속도
    [SerializeField]
    private float bulletSpeed = 10f;

    // 총알이 사라지는 타임
    [SerializeField]
    private float inActiveTime = 10f;

    // 총알이 생성된 시점부터 더해질 시간
    [SerializeField]
    private float startTime = 0f;

    void Update()
    {
        startTime += Time.deltaTime;

        // 총알이 계속 앞으로 날아감.
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        // 총알이 자동으로 없어지는 시간이 되면 비활성화 ( 오브젝트 풀 반환 )
        if( startTime > inActiveTime )
        {
            BulletObjectPool.instance.CoolObj(gameObject, PoolObjType.Bullet01);
            startTime = 0f;
        }
    }
}
