using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade04 : UpgradeUnit
{
    private void Start()
    {
        // 무기 ID, Cost, Level
        Init(
            JsonData.Instance.weaponDatas.Weapon[4].ID,
            JsonData.Instance.weaponDatas.Weapon[4].Cost,
            4
            );
    }

    //! 무기 변경
    public override void UpgradeWeapon()
    {
        base.UpgradeWeapon();
    }
}
