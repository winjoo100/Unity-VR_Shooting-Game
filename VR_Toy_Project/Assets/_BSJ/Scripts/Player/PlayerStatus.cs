using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // 플레이어 체력
    [Header("체력")]
    public int playerHp = 500;

    // 플레이어의 현재 무기
    [Header("현재 무기")]
    public int playerWeapon = 0;

    // 무기 프리팹
    public GameObject[] weapons;

    // 피격 이미지
    public Image hitImage;

    // 무적 상태 인지 확인
    [Header("무적상태 확인")]
    public bool isInvincible = false;

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

    // 플레이어 피격 시
    public void HitDamage_Player()
    {
        // 무적 상태 시 리턴
        if(isInvincible)
        {
            return;
        }

        // 무적 상태가 아니라면
        else
        {
            isInvincible = true;
            StartCoroutine(ActiveHitImage());
        }
        
    }

    // 플레이어 피격 시 피격 이미지 활성화/비활성화
    private IEnumerator ActiveHitImage()
    {
        hitImage.enabled = true;
        yield return new WaitForSeconds(1.5f);

        hitImage.enabled = false;

        // 무적 해제
        isInvincible = false;
    }
}
