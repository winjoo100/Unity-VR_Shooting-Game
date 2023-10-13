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

    private float spawnTime = 5f;
    

    void Start()
    {
        _monsterSpawner = gameObject;
    }

    private void Update()
    {
        
        Debug.Log(BossManager.instance.gametime);
        if(BossManager.instance.gametime > spawnTime)
        {
            CreateMonster();
            BossManager.instance.gametime = 0f;
        }
    }

    private void CreateMonster()
    {

            if (BossManager.instance.currentTime < 300f)
            {
                for (int i = 0; i < 5; i++)
                {
                    FirstWave();

                }
            }
            else if (300f < BossManager.instance.currentTime && BossManager.instance.currentTime < 600f)
            {
                for (int i = 0; i < 6; i++)
                {
                    SecondWave();

                }
            }
            else if (600f < BossManager.instance.currentTime && BossManager.instance.currentTime < 900f)
            {
                for (int i = 0; i < 7; i++)
                {
                    ThirdWave();

                }
            }
    }

        
    



    void FirstWave()
    {
        int spawnx=Random.Range(-500, 500);

        GameObject Mon1 = Instantiate(Monsterlv1, _monsterSpawner.transform.position, Quaternion.identity);
        Mon1.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);
    }

    void SecondWave()
    {
        int spawnx = Random.Range(-500, 500); 
        GameObject Mon2 = Instantiate(Monsterlv2, _monsterSpawner.transform);
        Mon2.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);
    }
    void ThirdWave()
    {
        int spawnx = Random.Range(-500, 500);
        GameObject Mon3 = Instantiate(Monsterlv3, _monsterSpawner.transform);
        Mon3.transform.position = new Vector3(spawnx, _monsterSpawner.transform.position.y, _monsterSpawner.transform.position.z);
    }

}
