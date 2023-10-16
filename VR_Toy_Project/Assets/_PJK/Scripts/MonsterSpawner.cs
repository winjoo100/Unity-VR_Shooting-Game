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
    void Start()
    {
        _monsterSpawner = GetComponent<GameObject>();
    }

    private void Update()
    {
        if(BossManager.instance.currentTime / 5 == 0)
        {
            if(BossManager.instance.currentTime < 300f)
            {
                FirstWave();
            }
            else if (300f < BossManager.instance.currentTime && BossManager.instance.currentTime < 600f)
            {
                SecondWave();
            }
            else if (600f < BossManager.instance.currentTime && BossManager.instance.currentTime < 900f)
            {
                ThirdWave();
            }


        }
    }

    void FirstWave()
    {
        GameObject Mon1 = Instantiate(Monsterlv1, _monsterSpawner.transform);
        Monsterlv1.transform.position = _monsterSpawner.transform.position;
    }

    void SecondWave()
    {
        GameObject Mon2 = Instantiate(Monsterlv2, _monsterSpawner.transform);
        Monsterlv2.transform.position = _monsterSpawner.transform.position;
    }
    void ThirdWave()
    {
        GameObject Mon3 = Instantiate(Monsterlv3, _monsterSpawner.transform);
        Monsterlv3.transform.position = _monsterSpawner.transform.position;
    }

}
