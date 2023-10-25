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
    // 강화 상점 UI 
    protected UpgradeConsolUI upgradeConsolUI = default;
    // } 강화 유닛이 가지고 있어야 하는 변수들

    private void Awake()
    {
        upgradeConsolUI = FindObjectOfType<UpgradeConsolUI>();
    }

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

        // 첫번째 구매 조건: 플레이어 현재 무기가 판매 무기보다 작거나 같을 것
        // 클때는 함수 종료
        if (playerStatus.playerWeapon > weaponLevel)
        {
            return;
        }

        Shot_BSJ shot = FindObjectOfType<Shot_BSJ>();

        // 두번째 구매 조건: 재화가 가격보다 크거나 같을 것
        // 재화가 충분한지 체크
        if (GameManager.Instance.Gold >= this.cost)
        {
            // 재화 차감
            GameManager.Instance.UseGold(this.cost);
        }
        // 충분하지 않음
        else if (GameManager.Instance.Gold < this.cost)
        {
            return;
        }

        // 무기 변경
        playerStatus.playerWeapon = weaponLevel;
        playerStatus.ChangeWeapon();
        // 탄환 변경
        shot.ChangeBullet();

        // UI 정보 갱신
        upgradeConsolUI.UpdateInfo(weaponLevel);
    }
}
