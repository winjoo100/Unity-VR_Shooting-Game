using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour
{
    // 총알의 속도
    [SerializeField]
    private float bulletSpeed = 30f;

    // 총알의 데미지
    [SerializeField]
    private float bulletDamage = 10f;

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
            GameObject hitVFX = VFXObjectPool.instance.GetPoolObj(VFXPoolObjType.Bullet01_HitVFX);
            hitVFX.SetActive(true);
            hitVFX.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);

            // 타격 데미지 텍스트 콜
            GameObject damageText = TextObjectPool.instance.GetPoolObj(TextPoolObjType.DamageText01);
            damageText.SetActive(true);
            damageText.transform.position = new Vector3(transform.position.x + Random.Range(-0.25f, 0.25f), transform.position.y + Random.Range(-0.25f, 0.25f), transform.position.z - 1f);

            // 탄환은 오브젝트 풀로 반환
            BulletObjectPool.instance.CoolObj(gameObject, PoolObjType.Bullet01);
        }
    }
}