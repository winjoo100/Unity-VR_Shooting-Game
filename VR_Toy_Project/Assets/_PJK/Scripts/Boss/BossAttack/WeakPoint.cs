using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour, IDamageable
{
    public Boss boss;

    public int weakpointhp = 100;

    private void Update()
    {
        if (weakpointhp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        // 스케일, 체력 초기화
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        weakpointhp = 100;
        boss.weakActiveCount--;
    }

    public void OnDamage(int damage)
    {
        weakpointhp -= damage;
    }
}
