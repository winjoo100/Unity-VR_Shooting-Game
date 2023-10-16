using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret01 : TurretUnit
{
    // head와 muzzle 인스펙터창에서 할당 필요

    private void Awake()
    {
        // 스탯 초기화
        Init("Turret01", 200, 150, 20, 40, 0.5f, 0);
    }

    private void Start()
    {
        // 공격 사이클 진행
        StartCoroutine(AttackRoutine());
    }
}
