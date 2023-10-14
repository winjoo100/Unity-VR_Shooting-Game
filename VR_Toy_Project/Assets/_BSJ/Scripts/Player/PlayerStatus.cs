using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // 플레이어 체력
    public int playerHp = 500;

    // 플레이어의 현재 무기
    public int playerWeapon = 0;

    // 무기 프리팹
    public GameObject[] weapons;

    private void Start()
    {
        ChangeWeapon();
    }

    // 무기 스왑
    public void ChangeWeapon()
    {
        foreach (GameObject weapon in weapons)
        {
            // 현재 무기라면,
            if (weapon == weapons[playerWeapon])
            {
                // 활성화
                weapon.SetActive(true);
            }

            // 다른 무기라면,
            else
            {
                // 비활성화
                weapon.SetActive(false);
            }
        }
    }
}
