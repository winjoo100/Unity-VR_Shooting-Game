using UnityEngine;
using System.Collections;
using System.Text;

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
    public GameObject player = default;
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

    public float AttackSpeed = default;
    public LayerMask turretLayer;
    public float detectionRadius = 100f;

    private Transform target = default;
    // 터렛을 타겟중인지 체크
    public bool isFindTurret = false;

    // 터렛을 공격중인지 체크
    public bool isAttackTurret = false;
    [SerializeField]
    public float AttackDmg = default;
    [SerializeField]
    private float hp;
    private int dmg;
    private float bombdmg;

    private Rigidbody rb; // 괴수의 Rigidbody를 사용하여 이동 처리
    private BoxCollider boxCollider;

    private TurretUnit tu = default;

    public int Lv1hp { get; private set; }
    public int Lv1atk { get; private set; }
    public float Lv1atkspeed { get; private set; }
    public int Lv1BombDmg { get; private set; }
    public int Lv2hp { get; private set; }
    public int Lv2atk { get; private set; }
    public float Lv2atkspeed { get; private set; }
    public int Lv2BombDmg { get; private set; }
    public int Lv3hp { get; private set; }

    public int Lv3atk { get; private set; }
    public float Lv3atkspeed { get; private set; }
    public int Lv3BombDmg { get; private set; }

    // TEST 
    // HSJ_ 2310119
    private SkinnedMeshRenderer meshRender;

    void Start()
    {
        tu = GetComponent<TurretUnit>();
        // 몬스터 초기값 셋팅
        Lv1hp = JsonData.Instance.monsterDatas.Monster[0].HP;
        Lv1atk = JsonData.Instance.monsterDatas.Monster[0].Att;
        Lv1BombDmg = JsonData.Instance.monsterDatas.Monster[0].Explosion_Damage;
        Lv1atkspeed = JsonData.Instance.monsterDatas.Monster[0].Att_Speed;

        Lv2hp = JsonData.Instance.monsterDatas.Monster[1].HP;
        Lv2atk = JsonData.Instance.monsterDatas.Monster[1].Att;
        Lv2BombDmg = JsonData.Instance.monsterDatas.Monster[1].Explosion_Damage;
        Lv2atkspeed = JsonData.Instance.monsterDatas.Monster[1].Att_Speed;

        Lv3hp = JsonData.Instance.monsterDatas.Monster[2].HP;
        Lv3atk = JsonData.Instance.monsterDatas.Monster[2].Att;
        Lv3BombDmg = JsonData.Instance.monsterDatas.Monster[2].Explosion_Damage;
        Lv3atkspeed = JsonData.Instance.monsterDatas.Monster[2].Att_Speed;

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
        boxCollider = GetComponent<BoxCollider>();

        //몬스터
        anim = GetComponent<Animator>();

        // TEST : 
        // HSJ_ 2310119
        meshRender = this.gameObject.GetChildObj("AnkleBiter").GetComponent<SkinnedMeshRenderer>();

    }

    private void OnEnable()
    {
        

    }

    private void Update()
    {
        // 터렛을 추격중이 아니면,
        if (target == null)
        {
            // 플레이어 추격
            MoveTowardsTarget(player.transform.position);
            
        }
        // 터렛을 콜라이더에서 발견하면
        else if (target == true)
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
                }

            }
            else if (isAttackTurret == true)
            {
                
                rb.velocity = Vector3.zero;
                AttackTurret(dmg);
            }

        }
        else if(Vector3.Distance(gameObject.transform.position,player.transform.position) < 20f )
        {
            AttackUser(bombdmg);
        }

        if(hp < 0)
        {
            Bomb(bombdmg);
        }


    }
    // 목표 지점으로 괴수를 이동시키는 함수
    void MoveTowardsTarget(Vector3 targetPosition)
    {
        gameObject.transform.forward = (targetPosition-gameObject.transform.position).normalized;
        
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }



    private void AttackTurret(int damage)
    {
        rb.velocity = Vector3.zero;
        anim.SetBool("isAttackturret", true);
        tu.DamageSelf(damage);
        // 멈춤
    }

    private void AttackUser(float damage)
    {
        rb.velocity = Vector3.zero;
        Bomb(damage);

    }

    private void Bomb(float damage)
    {
        MonsterBomb.instance.PlayEffect();

        Died();


    }

    private void Died()
    {
        if(hp<0)
        {
            boxCollider.enabled = false;
            hp = 0;
            anim.SetTrigger("isDied");
            MonsterBomb.instance.PlayEffect();
            StartCoroutine(inActive());
        }
    }

    IEnumerator ChangeColor()
    {

        meshRender.material.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        meshRender.material.color = Color.white;

    }

    public void OnDamage(int damage)
    {
        StartCoroutine(ChangeColor());
        hp -= damage;
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, turretLayer);

        if (colliders.Length > 0)
        {
            // 가장 가까운 터렛을 타겟으로 설정
            float closestDistance = float.MaxValue;

            foreach (Collider collider in colliders)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = collider.transform;
                }
            }
        }
        else
        {
            target = null;
        }
    }

    IEnumerator inActive()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}


