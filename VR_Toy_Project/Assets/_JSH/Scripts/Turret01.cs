using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;

public class Turret01 : TurretUnit
{
    // head와 muzzle 인스펙터창에서 할당 필요

    private void Awake()
    {
        // 스탯 초기화
        Init("Turret01", 1300, 200, 150, 20, 40, 0.5f, 0);
    }

    private void Update()
    {
        // 목표가 없으면 탐지 실행
        if (target == null || target == default)
        {
            DetectTarget();
        }

        // 공격이 준비되면 공격
        if (isReady == true)
        {
            isReady = false;

            AttackTarget();
        }
        else { /* DoNothing */ }
    }
}


//[CustomEditor(typeof(Turret01))]
//public class DestroyTurretEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        Turret01 target = GameObject.Find("Unit(Clone)").GetComponent<Turret01>();
//        if (GUILayout.Button("DamageSelf"))
//        {
//            target.DamageSelf(100);
//        }
//    }
//}
