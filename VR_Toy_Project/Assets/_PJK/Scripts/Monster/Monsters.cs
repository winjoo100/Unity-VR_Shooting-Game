using UnityEngine;
using System.Collections;

public class Monsters : MonoBehaviour, IDamageable
{
    //애니메이터 관련
    private Animator anim;

    //public bool isNoTurret = false;
    //public bool isAttackturret = false;
    //public bool isDied = false;
    
    //몬스터
    public GameObject monsterLevel = default;
    //플레이어
    private GameObject player = default;
    //터렛
    public GameObject turret = default;
    // 사정거리
    public float attackdistance = 20f;
    // 터렛과의 거리
    public float distanceToTurret = default;
    //감지 콜라이더
    public Collider detectCollider = default;
    // 이동 속도
    public float moveSpeed = 50.0f;

    // 터렛을 타겟중인지 체크
    public bool isFindTurret = false;

    // 터렛을 공격중인지 체크
    public bool isAttackTurret = false;
    [SerializeField]
    public float AttackDmg = default;
    [SerializeField]
    public float Hp = default;
    private Rigidbody rb; // 괴수의 Rigidbody를 사용하여 이동 처리

    private float hp;
    private float dmg;
    private float bombdmg;
    public float Lv1hp { get; private set; }
    public float Lv1atk { get; private set; }
    public float Lv1BombDmg { get; private set; }
    public float Lv2hp { get; private set; }
    public float Lv2atk { get; private set; }
    public float Lv2BombDmg { get; private set; }
    public float Lv3hp { get; private set; }

    public float Lv3atk { get; private set; }
    public float Lv3BombDmg { get; private set; }

    void Start()
    {
        //Debug.LogFormat("{0}", BossManager.instance == null);
        if (BossManager.instance.gametime < 300f)
        {
            hp = Lv1hp;
            dmg = Lv1atk;
            bombdmg = Lv1BombDmg;
        }
        else if (BossManager.instance.gametime > 300f && BossManager.instance.gametime < 600f)
        {
            hp = Lv2hp;
            dmg = Lv2atk;
            bombdmg = Lv2BombDmg;
        }
        else if (BossManager.instance.gametime > 600f)
        {
            hp = Lv3hp;
            dmg = Lv3atk;
            bombdmg = Lv3BombDmg;
        }
        player = GameObject.Find("Player");
        //data();

        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기

        //몬스터
        anim = GetComponent<Animator>();

        // 몬스터 초기값 셋팅
        Lv1hp = JsonData.Instance.monsterDatas.Monster[0].HP;
        Lv1atk = JsonData.Instance.monsterDatas.Monster[0].Att;
        Lv1BombDmg = JsonData.Instance.monsterDatas.Monster[0].Explosion_Damage;

        Lv2hp = JsonData.Instance.monsterDatas.Monster[1].HP;
        Lv2atk = JsonData.Instance.monsterDatas.Monster[1].Att;
        Lv2BombDmg = JsonData.Instance.monsterDatas.Monster[1].Explosion_Damage;

        Lv3hp = JsonData.Instance.monsterDatas.Monster[2].HP;
        Lv3atk = JsonData.Instance.monsterDatas.Monster[2].Att;
        Lv3BombDmg = JsonData.Instance.monsterDatas.Monster[2].Explosion_Damage;
    }

    private void OnEnable()
    {
        

    }

    private void Update()
    {
        // 체력이 0이되면 비활성화
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
        }

        // 터렛을 추격중이 아니면,
        if (isFindTurret == false)
        {
            // 플레이어 추격
            MoveTowardsTarget(player.transform.position);
        }
        // 터렛을 콜라이더에서 발견하면
        else if (isFindTurret == true)
        {    //터렛을 공격중이 아니라면
            if (isAttackTurret == false)
            {
                // 터렛 추격
                Vector3 targetPosition = turret.transform.position;


                // 현재 위치에서 타겟 방향과 거리 계산
                Vector3 toTarget = targetPosition - transform.position;

                if (toTarget.magnitude > attackdistance)
                {
                    // 이동
                    MoveTowardsTarget(targetPosition);
                }


                // 터렛과의 거리 비교
                distanceToTurret = Vector3.Distance(transform.position, turret.transform.position);

                // 터렛이 사정거리 안에 들어왔다면,
                if (distanceToTurret < attackdistance)
                {

                    // 터렛 공격
                    isAttackTurret = true;
                    AttackTurret(dmg);
                }

            }
            else if (isAttackTurret == true)
            {
                
                rb.velocity = Vector3.zero;

            }

        }
        else if(Vector3.Distance(gameObject.transform.position,player.transform.position)<20f )
        {
            AttackUser(Lv1BombDmg);
        }

        if(hp<0)
        {
            AttackUser(Lv1BombDmg);
        }


    }
    // 목표 지점으로 괴수를 이동시키는 함수
    void MoveTowardsTarget(Vector3 targetPosition)
    {
        gameObject.transform.forward = (targetPosition-gameObject.transform.position).normalized;
        
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }

    private void AttackTurret(float damage)
    {
        rb.velocity = Vector3.zero;
        //터렛 공격 함수
        //Tower.hp -= AttackDmg;
        anim.SetBool("isAttackturret", true);
        // 멈춤
    }

    private void AttackUser(float damage)
    {
        rb.velocity = Vector3.zero;
        Bomb();

    }

    private void Bomb()
    {
        MonsterBomb.instance.PlayEffect();
        Died();


    }

    private void Died()
    {
        if(hp<0)
        {
            hp = 0;
            anim.SetBool("isDied", true);
            MonsterBomb.instance.PlayEffect();
        }
    }

    public void OnDamage(float damage)
    {
        Hp -= damage;
    }


}


