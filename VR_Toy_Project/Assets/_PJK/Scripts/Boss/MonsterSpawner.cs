using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private GameObject _monsterSpawner = default;
    public GameObject boss = default;
    public GameObject Monsterlv1 = default;
    public GameObject Monsterlv2 = default;
    public GameObject Monsterlv3 = default;

    // 스폰 포인트
    public GameObject spawnPoint01;
    public GameObject spawnPoint02;

    // BSJ _ 테스트 용 시간 단축 
    public float testTimeReduce;

    private float spawnTime = 5f;
    

    void Start()
    {
        _monsterSpawner = gameObject;
    }

    private void Update()
    {
        
        if(BossManager.instance.spawn > spawnTime)
        {
            CreateMonster();
            BossManager.instance.spawn = 0f;
        }
    }

    private void CreateMonster()
    {

            if (BossManager.instance.currentTime < 300f * testTimeReduce)
            {
                for (int i = 0; i < 3; i++)
                {
                    FirstWave();

                }
            }
            else if (300f * testTimeReduce < BossManager.instance.currentTime && BossManager.instance.currentTime < 600f * testTimeReduce)
            {
                for (int i = 0; i < 4; i++)
                {
                    SecondWave();

                }
            }
            else if (600f * testTimeReduce < BossManager.instance.currentTime && BossManager.instance.currentTime < 900f * testTimeReduce)
            {
                for (int i = 0; i < 5; i++)
                {
                    ThirdWave();

                }
            }
    }

    void FirstWave()
    {
        int spawnx=Random.Range((int)spawnPoint01.transform.position.x, (int)spawnPoint02.transform.position.x);

        // Test: 오브젝트 풀을 사용하여 몬스터 소환
        GameObject monster01 = MonsterObjectPool.instance.GetPoolObj(MonsterPoolObjType.Monster_Lv1);
        monster01.SetActive(true);
        monster01.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);

        // 몬스터 생성 LEGACY : 오브젝트 풀에서 생성하기로 하였음. BSJ_231023
        // GameObject Mon1 = Instantiate(Monsterlv1, _monsterSpawner.transform.position, Quaternion.identity);
        // Mon1.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);
    }

    void SecondWave()
    {
        int spawnx = Random.Range((int)spawnPoint01.transform.position.x, (int)spawnPoint02.transform.position.x);

        // Test: 오브젝트 풀을 사용하여 몬스터 소환
        GameObject monster02 = MonsterObjectPool.instance.GetPoolObj(MonsterPoolObjType.Monster_Lv2);
        monster02.SetActive(true);
        monster02.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);

        // 몬스터 생성 LEGACY : 오브젝트 풀에서 생성하기로 하였음. BSJ_231023
        // GameObject Mon2 = Instantiate(Monsterlv2, _monsterSpawner.transform.position, Quaternion.identity);
        // Mon2.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);
    }
    void ThirdWave()
    {
        int spawnx = Random.Range((int)spawnPoint01.transform.position.x, (int)spawnPoint02.transform.position.x);

        // Test: 오브젝트 풀을 사용하여 몬스터 소환
        GameObject monster03 = MonsterObjectPool.instance.GetPoolObj(MonsterPoolObjType.Monster_Lv3);
        monster03.SetActive(true);
        monster03.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);

        // 몬스터 생성 LEGACY : 오브젝트 풀에서 생성하기로 하였음. BSJ_231023
        // GameObject Mon3 = Instantiate(Monsterlv3, _monsterSpawner.transform.position, Quaternion.identity);
        // Mon3.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);
    }

    // TODO: 몬스터 소환하는 함수 만들어야함.
}
