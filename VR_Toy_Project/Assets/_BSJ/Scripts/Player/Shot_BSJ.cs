using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_BSJ : MonoBehaviour
{
    // 공격속도 배율
    public float attackSpeedOffset = 1f;

    // 동일 공격속도
    [SerializeField]
    private float attackSpeed = 0.5f;

    // 공격 후 딜레이 시간
    [SerializeField]
    private float delayAttackTime = 0f;

    // 공격 가능한 지 판단 여부
    [SerializeField]
    private bool isAttack = true;

    // 총알 타입
    PoolObjType bulletType;

    // 진폭 조정
    private float handAmplitude = 0f;

    private PlayerStatus playerStat;

    private void Awake()
    {
        playerStat = GetComponent<PlayerStatus>();

        ChangeBullet();
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
            BSJVRInput.PlayVibration(0.2f, 1f, handAmplitude, BSJVRInput.Controller.RTouch);

            // 총알 발싸~
            GameObject bulletObj = BulletObjectPool.instance.GetPoolObj(bulletType);
            bulletObj.SetActive(true);

            bulletObj.transform.position = BSJVRInput.RHand.position;
            bulletObj.transform.rotation = BSJVRInput.RHand.rotation;

            // 공격 후 딜레이
            isAttack = false;
            delayAttackTime = 0f;
        }
    }

    public void ChangeBullet()
    {
        // 현재 탄환 타입
        bulletType = (PoolObjType)playerStat.playerWeapon;

        // 공격 속도 조정
        if (bulletType == PoolObjType.Bullet01) { attackSpeed = 0.5f; }
        else if (bulletType == PoolObjType.Bullet02) { attackSpeed = 0.5f; }
        else if (bulletType == PoolObjType.Bullet03) { attackSpeed = 0.4f; }
        else if (bulletType == PoolObjType.Bullet04) { attackSpeed = 0.4f; }
        else if (bulletType == PoolObjType.Bullet05) { attackSpeed = 0.3f; }

        // 진폭 조정
        if (bulletType == PoolObjType.Bullet01) { handAmplitude = 2f; }
        else if (bulletType == PoolObjType.Bullet02) { handAmplitude = 4f; }
        else if (bulletType == PoolObjType.Bullet03) { handAmplitude = 6f; }
        else if (bulletType == PoolObjType.Bullet04) { handAmplitude = 4f; }
        else if (bulletType == PoolObjType.Bullet05) { handAmplitude = 10f; }
    }
}

