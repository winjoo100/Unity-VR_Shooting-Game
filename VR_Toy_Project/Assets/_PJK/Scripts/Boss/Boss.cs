using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{    
    public GameObject boss = default;
    public GameObject player = default;
    public GameObject[] Turret = default;
    // 터렛을 타겟중인지 체크
    public bool isFindTurret = false;
    // 터렛을 공격중인지 체크
    public bool isAttackTurret = false;
    // 약점포인트 공격당했는지 체크
    public bool isAttackedWeakPoint = false;
    // 죽었는지 체크
    public bool isDead = false;
    public BossManager bm = default;
    private Monsters m = default;
    // 약점 포인트 프리팹들
    public GameObject[] weakpoints;

    // 몇개가 활성화 되어있는지 체크
    public int weakActiveCount = 0;

    private Rigidbody rb;

    // HSJ_ 231019
    // 프로퍼티로 변경
    // { GameManger에서 가져가서 사용할 변수
    public int MaxHp { get; private set; }
    public int CurHP { get; private set; }
    private int lastGoldHP = default;
    // { GameManger에서 가져가서 사용할 변수
    private float BossAtk;

    void Start()
    {
        // 보스 초기 값 셋팅
        MaxHp = JsonData.Instance.bossDatas.Boss_Data[0].Hp;
        lastGoldHP = MaxHp;
        CurHP = MaxHp;

        StartCoroutine(_BossMove());

        // 약점 프리팹 모두 비활성화
        OffWeakPoint();
        m = GetComponent<Monsters>();
    }

    private IEnumerator _BossMove()
    {
        Vector3 startLocation = boss.transform.position;
        Vector3 targetLocation = player.transform.position;

        float yPosition = startLocation.y;
        //시작하는시간
        BossManager.instance.currentTime = 0f;
        //도착하는데 도달하는 시간(초)
        float finishTime = BossManager.instance.EndGame;
        // 경과율
        BossManager.instance.elapsedRate = BossManager.instance.currentTime / finishTime;
        while (BossManager.instance.elapsedRate < 1)
        {
            BossManager.instance.currentTime += Time.deltaTime;
            BossManager.instance.elapsedRate = BossManager.instance.currentTime / finishTime;
            // TEST : * 5f
            boss.transform.position = Vector3.Lerp(startLocation, targetLocation, BossManager.instance.elapsedRate * 5f);
            // Y 위치를 고정
            Vector3 newPosition = new Vector3(
                Mathf.Lerp(startLocation.x, targetLocation.x, BossManager.instance.elapsedRate),
                yPosition, // 고정된 Y 위치
                Mathf.Lerp(startLocation.z, targetLocation.z, BossManager.instance.elapsedRate)
            );
            boss.transform.position = newPosition;
            yield return null;
        }

    }

    private void Update()
    {
        // 정근정근아 작동되는 코드를 넣어라
        //if (m.isFindTurret == true)
        //{
        //    if (m.isAttackTurret == true)
        //    {
        //        //AttackTurret();
        //        rb.velocity = Vector3.zero;
        //    }
        //}

        if (bm.Weaknesstime > 10 || weakActiveCount == 0)
        {
            // 기존 약점 비활성화
            OffWeakPoint();

            // 약점 활성화
            OnWeakPoint();
            bm.Weaknesstime = 0;
        }

        if (CurHP <= 0)
        {

            Death();
        }


    }

    public void FindTurret()
    {

    }


    private void AttackedWeakPoint()
    {
        isAttackedWeakPoint = true;
    }


    private void Death()
    {
        
        isDead = true;
        //TODO : 게임종료 승리

    }

    void OnWeakPoint()
    {
        for (int i = 0; i < 3; i++)
        {
            int onweak = Random.Range(0, 8);

            weakpoints[onweak].SetActive(true);

            if (i == 0)
            {
                weakpoints[onweak].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }

            weakActiveCount = 3;
        }
    }

    void OffWeakPoint()
    {
        // 약점 프리팹 모두 비활성화
        for (int i = 0; i < weakpoints.Length; i++)
        {

            weakpoints[i].SetActive(false);
        }

        weakActiveCount = 0;
    }

    public void OnDamage(int damage)
    {
        CurHP -= damage;
        CalculateHp();
    }
    private void CalculateHp()
    {        
        int rateHp = (int)(MaxHp * 0.1f);
        
        if (CurHP <= lastGoldHP - rateHp)
        {
            GameManager.Instance.GetGold_Boss();
            lastGoldHP = lastGoldHP - rateHp;
        }
    }
}
