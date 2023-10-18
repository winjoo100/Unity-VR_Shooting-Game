using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private GameObject boss;
    public BossManager bm;
    public GameObject player = default;
    public GameObject Plane = default;
    public GameObject playerAttack = default;
    public GameObject TowerAttack = default;
    public GameObject monsterAttack = default;
    public LayerMask Turret = default;


    private void Awake()
    {

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

        int skill = Random.Range(0, 1);
        int skillx = Random.Range(-250, 250);
        int skilly = Random.Range(0, 80);

        if (skill == 0)
        {
            
            GameObject atktoplayer = Instantiate(playerAttack, boss.transform.position,Quaternion.identity);
            //atktoplayer.transform.position = new Vector3(boss.transform.position.x, boss.transform.position.y + 10, boss.transform.position.z);

        }
        else if (skill == 1)
        {
            GameObject atktotower = Instantiate(TowerAttack, boss.transform.position, Quaternion.identity);
            //atktotower.transform.position = new Vector3(boss.transform.position.z, boss.transform.position.y, boss.transform.position.z);

        }
        else if(skill==1)
        {
            GameObject spawnmon = Instantiate(monsterAttack, boss.transform.position, Quaternion.identity);
            //spawnmon.transform.position = new Vector3(boss.transform.position.z, boss.transform.position.y, boss.transform.position.z);

        }
    }
}
