using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade03 : UpgradeUnit
{
    private void Start()
    {
        // 무기 ID, Cost, Level
        Init(
            JsonData.Instance.weaponDatas.Weapon[3].ID,
            JsonData.Instance.weaponDatas.Weapon[3].Cost,
            3
            );
    }

    //! 무기 변경
    public override void UpgradeWeapon()
    {
        base.UpgradeWeapon();
    }
}
