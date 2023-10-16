using UnityEngine;

public class Monsters : MonoBehaviour
{
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

    private Rigidbody rb; // 괴수의 Rigidbody를 사용하여 이동 처리

    void Start()
    {
        player = GameObject.Find("Player");

        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
    }

    private void Update()
    {
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
                }

            }
            else if (isAttackTurret == true)
            {
                //AttackTurret();
                rb.velocity = Vector3.zero;
            }

        }





        // 다른 로직에 따라 공격 로직을 추가할 수 있습니다.
    }

    // 목표 지점으로 괴수를 이동시키는 함수
    void MoveTowardsTarget(Vector3 targetPosition)
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }

    private void AttackTurret()
    {
        // 멈춤
        rb.velocity = Vector3.zero;
        //터렛 공격 함수

    }




}


