using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MonsterDeathBomb : MonoBehaviour
{
    public float _Damage = default;

    private void Start()
    {
        // 테스트 용 데미지 증가
        _Damage *= 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        // { 폭발 데미지 처리
        // 플레이어
        if(other.CompareTag("Player"))
        {
            // TODO: 플레이어 스탯에서 OnDamage 함수 받아와서 실행 시켜야함.
            //other.GetComponent<PlayerStatus>()
        }
        // 터렛
        if(other.CompareTag("Turret"))
        {
            // 데미지 처리
            other.GetComponent<TurretUnit>().DamageSelf((int)_Damage);

            // 텍스트 콜
            TextCall((int)_Damage, other.transform);
        }

        // 몬스터
        if(other.CompareTag("Monster"))
        {
            // 데미지 처리
            other.GetComponent<Monsters>().OnDamage((int)_Damage);

            // 텍스트 콜
            TextCall((int)_Damage, other.transform);
        }
        // } 폭발 데미지 처리
    }

    //! 데미지 텍스트를 불러오는 함수
    private void TextCall(int _damage, Transform target)
    {
        // 텍스트 콜
        GameObject damageText = TextObjectPool.instance.GetPoolObj(TextPoolObjType.DamageText02);
        damageText.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("{0}", _damage);
        damageText.SetActive(true);
        damageText.transform.position = target.position;
    }
}
