using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUnit : MonoBehaviour
{
    // { 강화 유닛이 가지고 있어야 하는 변수들
    // ID
    protected int unitID = default;
    // 가격
    protected int cost = default;
    // 강화 단계
    protected int weaponLevel = 0;
    // } 강화 유닛이 가지고 있어야 하는 변수들

    //! 강화 유닛의 정보 초기화
    protected virtual void Init(int unitID_, int cost_, int level_)
    {
        unitID = unitID_;
        cost = cost_;
        weaponLevel = level_;
    }

    //! 플레이어의 무기 변경
    public virtual void UpgradeWeapon()
    {
        PlayerStatus playerStatus = FindObjectOfType<PlayerStatus>();
        Shot_BSJ shot = FindObjectOfType<Shot_BSJ>();

        // TODO: cost보다 재화가 적으면 return
        // TODO: cost만큼 재화 감소

        playerStatus.playerWeapon = weaponLevel;
        playerStatus.ChangeWeapon();
        shot.ChangeBullet();
    }
}
