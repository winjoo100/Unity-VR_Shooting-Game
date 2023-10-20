using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turret01 : TurretUnit
{
    // head와 muzzle 인스펙터창에서 할당 필요

    private void Awake()
    {
        // 스탯 초기화
        Init(
            JsonData.Instance.unitDatas.Unit[0].Name,
            JsonData.Instance.unitDatas.Unit[0].ID,
            JsonData.Instance.unitDatas.Unit[0].HP,
            JsonData.Instance.unitDatas.Unit[0].Cost,
            JsonData.Instance.unitDatas.Unit[0].Install_Limit,
            JsonData.Instance.unitDatas.Unit[0].Range,
            JsonData.Instance.unitDatas.Unit[0].Firing_Interval,
            JsonData.Instance.unitDatas.Unit[0].Bullet_Table_ID
            );
    }

    private void Start()
    {
        // 터렛의 존재 유무와 갯수를 세기 위해 추가
        GameManager.Instance.turretLv1_List.Add(transform);
    }

    private void OnEnable()
    {
        DetectTarget();
    }

    private void Update()
    {
        //// 탐지
        //if (isReadyDetect == true)
        //{
        //    isReadyDetect = false;

        //    DetectTarget();
        //}

        //// 공격이 준비되면 공격
        //if (isReadyAttack == true)
        //{
        //    isReadyAttack = false;

        //    AttackTarget();
        //}
        //else { /* DoNothing */ }
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
