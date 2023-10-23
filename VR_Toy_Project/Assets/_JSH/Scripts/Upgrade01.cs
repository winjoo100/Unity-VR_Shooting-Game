using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade01 : UpgradeUnit
{
    private void Start()
    {
        // 무기 ID, Cost, Level
        Init(
            JsonData.Instance.weaponDatas.Weapon[1].ID,
            JsonData.Instance.weaponDatas.Weapon[1].Cost,
            1
            );
    }

    //! 무기 변경
    public override void UpgradeWeapon()
    {
        base.UpgradeWeapon();
    }
}
