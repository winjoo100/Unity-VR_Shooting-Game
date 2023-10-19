using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private GameObject boss;
    public BossManager bm;
    public GameObject player = default;
    public GameObject playerAttack = default;
    public GameObject TowerAttack = default;
    public GameObject monsterAttack = default;
    public LayerMask Turret = default;
    private GameObject target = default;
    private Monsters m = default;
    private int skill = default;

    private void Awake()
    {
        m = GetComponent<Monsters>();
        boss = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(boss.transform.position, 100f, Turret);

        
        if (bm.skillCoolTime > 20)
        {
            attack();
            bm.skillCoolTime = 0;

        }
    }

    void attack()
    {
        float zrange = Vector3.Distance(gameObject.transform.position, player.transform.position);
        
        // 정근정근아 뒤질래? 
        // 동작하는 코드를 넣으라고.. 주석 달던가
        //if(m.isFindTurret==true)
        //{
        //     skill = Random.Range(0, 2);
        //}
        //else if(m.isFindTurret==false)
        //{
        //    skill = Random.Range(0, 1);
        //}


        if (skill == 0)
        {
            int howmanyAttack = Random.Range(2, 5);
            for (int i = 0; i < howmanyAttack; i++)
            {
                GameObject atktoplayer = Instantiate(playerAttack, boss.transform.position, Quaternion.identity);
            }

        }

        else if (skill == 1)
        {
            int howmanyAttack = Random.Range(1, 3);
            for (int i = 0; i < howmanyAttack; i++)
            {
                GameObject spawnmon = Instantiate(monsterAttack, boss.transform.position, Quaternion.identity);
            }
        }

        else if (skill == 2)
        {
            int howmanyAttack = Random.Range(1, 3);
            for (int i = 0; i < howmanyAttack; i++)
            {
                GameObject atktotower = Instantiate(TowerAttack, boss.transform.position, Quaternion.identity);
            }
        }
    }
}
