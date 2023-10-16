using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public float elapsedRate = default;
    public float currentTime = default;
    public float gametime = default;
    public float spawn = default;

    public float BossHp = 10000;
    public float EndGame = 1500;
    public float BossAttackDamage = 100;




    public float Lv1MonsterHp = 10;
    public float Lv1MonsterDamage = 10;

    public float Lv2MonsterHp = 20;
    public float Lv2MonsterDamage = 20;

    public float Lv3MonsterHp = 20;
    public float Lv3MonsterDamage = 30;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        spawn += Time.deltaTime;
        gametime += Time.deltaTime;
        //Debug.Log(gametime);
    }
}
