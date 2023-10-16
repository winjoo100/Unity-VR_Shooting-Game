using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    // 총알의 타입
    public PoolObjType bulletType;

    // 총알 타격 이펙트
    private VFXPoolObjType vfxType;

    // 총알 데미지 텍스트
    private TextPoolObjType textType;

    // 총알의 속도
    [SerializeField]
    private float bulletSpeed = 30f;

    // 총알의 데미지
    [SerializeField]
    private float bulletDamage = 10f;

    private void Start()
    {
        // { 총알 타입에 따른 총알 조정
        if (bulletType == PoolObjType.Bullet01)
        {
            vfxType = VFXPoolObjType.Bullet01_HitVFX;
            textType = TextPoolObjType.DamageText01;
            bulletDamage = 10f;
        }
        else if (bulletType == PoolObjType.Bullet02)
        {
            vfxType = VFXPoolObjType.Bullet02_HitVFX;
            textType = TextPoolObjType.DamageText01;
            bulletDamage = 20f;
        }
        // } 총알 타입에 따른 총알 조정
    }

    void Update()
    {
        // 총알이 계속 앞으로 날아감.
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 적과 맞으면, 
        if (other.CompareTag("Enemy"))
        {
            // 타격 이펙트 콜
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(vfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);

            // { 타격 데미지 텍스트 콜
            GameObject damageText = TextObjectPool.instance.GetPoolObj(textType);

            // 총알 데미지 텍스트 변경
            damageText.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("{0}", bulletDamage /* 추후 치명타율 치명타배율 추가공격력 계산 식 추가 예정 */);

            damageText.SetActive(true);
            damageText.transform.position = new Vector3(transform.position.x + Random.Range(-0.25f, 0.25f), transform.position.y + Random.Range(-0.25f, 0.25f), transform.position.z - 1f);
            // } 타격 데미지 텍스트 콜

            // 탄환은 오브젝트 풀로 반환
            BulletObjectPool.instance.CoolObj(gameObject, bulletType);
        }

        // 다른 곳에 맞으면
        else if (other.CompareTag("Terrain"))
        {
            // 타격 이펙트 콜
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(vfxType);
            hitVFX.SetActive(true);
            hitVFX.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

            // 탄환 오브젝트 풀로 반환
            BulletObjectPool.instance.CoolObj(gameObject, bulletType);
        }

        else { /* Do Nothing */ }
    }
}