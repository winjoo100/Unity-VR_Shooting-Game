using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade02 : UpgradeUnit
{
    private void Start()
    {
        // 무기 ID, Cost, Level
        Init(
            JsonData.Instance.weaponDatas.Weapon[2].ID,
            JsonData.Instance.weaponDatas.Weapon[2].Cost,
            2
            );
    }

    //! 무기 변경
    public override void UpgradeWeapon()
    {
        base.UpgradeWeapon();
    }
}
