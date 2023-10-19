using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class BossBombAttackTurret : MonoBehaviour, IDamageable
{
    // 공격 포탄 Hp
    public int BossBombAttackHp = default;

    public float initialAngle = 30f;    // 처음 날라가는 각도
    public GameObject target;
    private float Shottime;
    private Rigidbody rb;               // Rigidbody
    private int randomX;

    private Turret01[] turret01;
    private Turret02[] turret02;

    private float nearDistance;
    private GameObject tempTarget;
    private void Awake()
    {
        // 체력 셋팅
        BossBombAttackHp = JsonData.Instance.bossSkillDatas.Boss_Skill[0].Hp;

        rb = GetComponent<Rigidbody>();
        Shottime = 0;
        nearDistance = Mathf.Infinity;

        turret01 = FindObjectsOfType<Turret01>();
        turret02 = FindObjectsOfType<Turret02>();
        // TODO : turret03, turret04찾기
        // TODO: if 터렛이 있으면 target은 터렛


        // TODO: else 터렛이 없으면 target은 플레이어
        target = GameObject.Find("Player");

        if (turret01.Length > 0)
        {
            // 제일 가까운 터렛 찾기
            for (int i = 0; i < turret01.Length; i++)
            {
            Debug.Log("t1 : "+i);
                float findDistance = Vector3.Distance(transform.position, turret01[i].transform.position);

                // 제일 가깝다면 그 타겟을 저장하고,
                if (nearDistance > findDistance)
                {
                    nearDistance = findDistance;
                    target = turret01[i].gameObject;
                }
            }
        }

        if (turret02.Length > 0)
        {
            Debug.Log("t2");
            for (int i = 0; i < turret02.Length ; i++)
            {
                float findDistance = Vector3.Distance(transform.position, turret02[i].transform.position);

                // 제일 가깝다면 그 타겟을 저장하고,
                if (nearDistance > findDistance)
                {
                    nearDistance = findDistance;
                    target = turret02[i].gameObject;
                }
            }
        }

        Debug.Log("끝");
    }


    private void Start()
    {
        randomX = Random.Range(-15,15);

        StartCoroutine(Firsttime());

    }

    private void Update()
    {
        // 체력이 0이되면 비활성화
        if (BossBombAttackHp <= 0 )
        {
            gameObject.SetActive(false);
        }
    }


    IEnumerator Firsttime()
    {
        Debug.Log("시작");
        rb.useGravity = false;
        Vector3 velocity = new Vector3(randomX, 10, 0);
        rb.velocity = velocity;

        Debug.Log("이동끝");
        yield return new WaitForSeconds(1.5f);
        rb.velocity = Vector3.zero;

        Debug.Log("발사준비");
        yield return new WaitForSeconds(1.5f);

        Debug.Log("발사");
        rb.useGravity = true;
        // 포물선 운동
        velocity = GetVelocity(transform.position, target.transform.position, initialAngle);

        rb.velocity = velocity;
    }


    public Vector3 GetVelocity(Vector3 startPos, Vector3 target, float initialAngle)
    {
        float gravity = Physics.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 targetPos = new Vector3(target.x, 0, target.z); // y 좌표를 0으로 설정하여 y 값을 무시
        Vector3 shotPos = new Vector3(startPos.x, 0, startPos.z); // y 좌표를 0으로 설정하여 y 값을 무시

        float distance = Vector3.Distance(targetPos, shotPos);
        float yOffset = startPos.y - target.y; // yOffset을 0으로 설정하여 높이를 고려하지 않음


        if (distance <= 0 || yOffset <= 0)
        {
            return Vector3.zero;
        }

        float initialVelocity
           = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity
             = new Vector3(0f, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects
            = Vector3.Angle(Vector3.forward, targetPos - shotPos) * (target.x > startPos.x ? 1 : -1);
        Vector3 finalVelocity
            = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        return finalVelocity;
    }

    public void OnDamage(int damage)
    {
        BossBombAttackHp -= damage;
    }
}