using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretButton01 : MonoBehaviour
{
    // 터렛 ID
    private int turretID = default;
    // PlaceUnit class
    private PlaceUnit placeUnit = default;

    private void Awake()
    {
        // TODO: CSV 읽어서 넣어줘야함
        turretID = 1300;

        // PlaceUnit 가져오기
        placeUnit = FindObjectOfType<PlaceUnit>();
    }

    //! ID SET 후 유닛 배치 실행
    public void PlaceTurret()
    {
        // ID에 해당하는 터렛 설정
        placeUnit.SetID(turretID);
    }
}
