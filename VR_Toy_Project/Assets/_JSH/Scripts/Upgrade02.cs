using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade02 : UpgradeUnit
{
    private void Awake()
    {
        Init(1002, 1000, 2);
    }

    //! 무기 변경
    public override void UpgradeWeapon()
    {
        base.UpgradeWeapon();
    }
}
