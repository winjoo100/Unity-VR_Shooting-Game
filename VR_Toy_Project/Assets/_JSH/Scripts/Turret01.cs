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

        // 터렛 상점 UI
        TurretConsolUI turretConsolUI = FindObjectOfType<TurretConsolUI>();
        turretConsolUI.UpdateCnt(unitID);
    }

    private void OnEnable()
    {
        DetectTarget();
    }

    protected override void DestroySelf()
    {
        // 배치된 터렛 수 감소
        GameManager.Instance.turretLv1_List.Remove(transform);

        base.DestroySelf();
    }
}

// Inspector 창에서 사용할 수 있도록 해주는 코드
// 누르면 기능이 작동하는 버튼이 생긴다
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
