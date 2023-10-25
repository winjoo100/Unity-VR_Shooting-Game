using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret02 : TurretUnit
{
    private void Awake()
    {
        // 스탯 초기화
        Init(
            JsonData.Instance.unitDatas.Unit[1].Name,
            JsonData.Instance.unitDatas.Unit[1].ID,
            JsonData.Instance.unitDatas.Unit[1].HP,
            JsonData.Instance.unitDatas.Unit[1].Cost,
            JsonData.Instance.unitDatas.Unit[1].Install_Limit,
            JsonData.Instance.unitDatas.Unit[1].Range,
            JsonData.Instance.unitDatas.Unit[1].Firing_Interval,
            JsonData.Instance.unitDatas.Unit[1].Bullet_Table_ID
            );
    }

    private void Start()
    {
        // 터렛의 존재 유무와 갯수를 세기 위해 추가
        GameManager.Instance.turretLv2_List.Add(transform);

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
        GameManager.Instance.turretLv2_List.Remove(transform);

        base.DestroySelf();
    }
}
