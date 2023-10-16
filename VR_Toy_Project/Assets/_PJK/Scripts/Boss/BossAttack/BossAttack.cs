using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BossAttack : MonoBehaviour
{
    private GameObject boss;
    public BossManager bm;
    public GameObject Plane = default;
    public GameObject playerAttack = default;
    public GameObject TowerAttack = default;
    public GameObject monsterAttack = default;
    public LayerMask Turret = default;

    private void Awake()
    {
        boss = GetComponent<GameObject>();
        bm = GetComponent<BossManager>();

    }


    // Update is called once per frame
    void Update()
    {
       Collider[] colliders= Physics.OverlapSphere(boss.transform.position, 100f, Turret);
       
        if (bm.gametime == 20)
        {
            attack();
        }
    }

    void attack()
    {
        int skill = Random.Range(0, 1);
        int skillx = Random.Range(-250, 250);
        int skilly = Random.Range(0, 80);

        if (skill == 0)
        {
            GameObject atktoplayer =Instantiate(playerAttack, boss.transform);
            atktoplayer.transform.position = new Vector3(skillx, skilly, boss.transform.position.z);

        }
        else if( skill ==1)
        {
            GameObject atktotower = Instantiate(TowerAttack, boss.transform);
            atktotower.transform.position = new Vector3(skillx, skilly, boss.transform.position.z);

        }
        else if(skill==2)
        {
            GameObject spawnmon = Instantiate(monsterAttack, boss.transform);
            spawnmon.transform.position = new Vector3(skillx, skilly, boss.transform.position.z);

        }
    }
}
