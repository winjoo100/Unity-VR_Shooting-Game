using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public float elapsedRate = default;
    public float currentTime = default;
    public float gametime = default;
    public float spawn = default;

    //보스 hp
    public float BossHp = 10000;
    //게임이 종료되는 시간
    public float EndGame = 1500;

    /// <summary>
    /// 보스 원거리 관련
    /// </summary>
    //보스 플레이어공격력
    public float BossAttackPlayer = 100;
    //보스 포탑 공격력
    public float BossAttackTurret = 200;


    /// <summary>
    /// 몬스터관련
    /// </summary>
    public float Lv1MonsterHp = 100;
    public float Lv1MonsterDamage = 10;

    public float Lv2MonsterHp = 200;
    public float Lv2MonsterDamage = 20;

    public float Lv3MonsterHp = 300;
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
