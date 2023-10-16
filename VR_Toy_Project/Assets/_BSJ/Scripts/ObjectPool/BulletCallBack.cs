using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCallBack : MonoBehaviour
{
    // 총알 타입
    public PoolObjType bulletType;

    // 자동으로 반환되는 시간
    [SerializeField]
    private float bulletReturnTime = 10f;

    // 생성된 시점부터 더해질 시간
    [SerializeField]
    private float startTime = 0f;

    private void Update()
    {
        // 생성된 시점부터 몇 초가 지났는지 더해주기
        startTime += Time.deltaTime;

        // 총알이 반환되는 시간이 되면 반환
        if(startTime > bulletReturnTime)
        {
            // 오브젝트 풀로 반환
            BulletObjectPool.instance.CoolObj(gameObject, bulletType);
            startTime = 0f;
        }
    }

    private void OnDisable()
    {
        startTime = 0f;
    }
}
