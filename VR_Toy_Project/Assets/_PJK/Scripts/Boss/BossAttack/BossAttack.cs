using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Boss boss;
    public BossManager bm;
    public GameObject player = default;
    public GameObject playerAttack = default;
    public GameObject TowerAttack = default;
    public GameObject monsterAttack = default;
    public LayerMask Turret = default;
    private Monsters m = default;
    private int skill = default;
    //BSJ_231024
    private Vector3 yOffset = new(0f, 2f, 0f);

    private void Awake()
    {
        m = GetComponent<Monsters>();
        boss = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(boss.transform.position, 100f, Turret);



        if (bm.skillCoolTime > 20f && boss.CurHP > 100)
        {
            attack();
            bm.skillCoolTime = 0;

        }
    }

    void attack()
    {
        float zrange = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (GameManager.Instance.turretLv1_List.Count + GameManager.Instance.turretLv2_List.Count + GameManager.Instance.turretLv3_List.Count + GameManager.Instance.turretLv4_List.Count > 0)
        {
            skill = Random.Range(0, 3);
        }
        else if (GameManager.Instance.turretLv1_List.Count + GameManager.Instance.turretLv2_List.Count + GameManager.Instance.turretLv3_List.Count + GameManager.Instance.turretLv4_List.Count < 1)
        {
            skill = Random.Range(0, 2);
        }


        if (skill == 0)
        {
            int howmanyAttack = Random.Range(2, 6);

            for (int i = 0; i < howmanyAttack; i++)
            {
                // 사운드 출력
                SoundManager.instance.PlaySE("BossAttack");

                // 플레이어 공격 투사체 생성
                GameObject atktoplayer = BossAttackObjectPool.instance.GetPoolObj(BossAttackPoolObjType.BossAttackPlayer);
                atktoplayer.SetActive(true);
                atktoplayer.transform.position = transform.position + yOffset;

                //LEGACY : 오브젝트 풀에서 생성
                //GameObject atktoplayer = Instantiate(playerAttack,new Vector3(boss.transform.position.x, boss.transform.position.y+2f, boss.transform.position.z),Quaternion.identity);

            }

        }

        else if (skill == 1)
        {
            int howmanyAttack = Random.Range(1, 4);
            for (int i = 0; i < howmanyAttack; i++)
            {
                // 사운드 출력
                SoundManager.instance.PlaySE("BossAttack");

                // 몬스터 스폰 투사체 생성
                GameObject spawnmon = BossAttackObjectPool.instance.GetPoolObj(BossAttackPoolObjType.BossAttackSpawnMon);
                spawnmon.SetActive(true);
                spawnmon.transform.position = transform.position + yOffset;

                //LEGACY : 오브젝트 풀에서 생성
                //GameObject spawnmon = Instantiate(monsterAttack, new Vector3(boss.transform.position.x, boss.transform.position.y + 2f, boss.transform.position.z), Quaternion.identity);
            }
        }

        else if (skill == 2)
        {
            int howmanyAttack = Random.Range(1, 4);
            for (int i = 0; i < howmanyAttack; i++)
            {
                // 사운드 출력
                SoundManager.instance.PlaySE("BossAttack");

                // 터렛 공격 투사체 생성
                GameObject atktotower = BossAttackObjectPool.instance.GetPoolObj(BossAttackPoolObjType.BossAttackTurret);
                atktotower.SetActive(true);
                atktotower.transform.position = transform.position + yOffset;

                //LEGACY : 오브젝트 풀에서 생성
                //GameObject atktotower = Instantiate(TowerAttack, new Vector3(boss.transform.position.x, boss.transform.position.y + 2f, boss.transform.position.z), Quaternion.identity);
            }
        }
    }
}
