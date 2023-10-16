using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade01 : UpgradeUnit
{
    private void Awake()
    {
        Init(1001, 1000, 1);
    }

    //! 무기 변경
    public override void UpgradeWeapon()
    {
        base.UpgradeWeapon();
    }
}
