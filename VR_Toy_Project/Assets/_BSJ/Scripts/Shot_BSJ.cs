using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_BSJ : MonoBehaviour
{
    // 동일 공격속도
    [SerializeField]
    private float attackSpeed = 1f;

    // 공격속도 배율
    [SerializeField]
    private float attackSpeedOffset = 1f;

    // 공격 후 딜레이 시간
    [SerializeField]
    private float delayAttackTime = 0f;

    // 공격 가능한 지 판단 여부
    [SerializeField]
    private bool isAttack = true;

    private void Start()
    {
        // 총알 FX(Effect) 파티클 시스템 컴포넌트 가져오기
        // bulletEffect = bulletImpact.GetComponent<ParticleSystem>();

        // 총알 FX 오디오 소스 컴포넌트 가져오기
        // bulletAudio = bulletImpact.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isAttack == false)
        {
            // 공격 쿨타임이 On되면 공격가능
            delayAttackTime += Time.deltaTime * attackSpeedOffset;

            if (delayAttackTime > attackSpeed) 
            { isAttack = true; }
        }
        

        // 크로스 헤어 표시
        //BSJVRInput.DrawCrosshair(crosshair);

        // 사용자가 IndexTrigger 버튼을 누르면
        if (BSJVRInput.Get(BSJVRInput.Button.IndexTrigger) && isAttack == true)
        {
            // 컨트롤러의 진동 재생
            BSJVRInput.PlayVibration(0.1f, 1f, 2f, BSJVRInput.Controller.RTouch);

            // 총알 발싸~
            GameObject bulletObj = BulletObjectPool.instance.GetPoolObj(PoolObjType.Bullet01);
            bulletObj.SetActive(true);

            bulletObj.transform.position = BSJVRInput.RHand.position;
            bulletObj.transform.rotation = BSJVRInput.RHand.rotation;

            // 공격 후 딜레이
            isAttack = false;
            delayAttackTime = 0f;
        }
    }
}

