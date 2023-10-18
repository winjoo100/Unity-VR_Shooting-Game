using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject boss = default;
    public GameObject player = default;
    public GameObject Turret = default;
    // 터렛을 타겟중인지 체크
    public bool isFindTurret = false;
    // 터렛을 공격중인지 체크
    public bool isAttackTurret = false;
    // 약점포인트 공격당했는지 체크
    public bool isAttackedWeakPoint = false;
    // 죽었는지 체크
    public bool isDead = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(_BossMove());

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
            boss.transform.position = Vector3.Lerp(startLocation, targetLocation, BossManager.instance.elapsedRate);
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
        if (isFindTurret == true)
        {
            if (isAttackTurret == true)
            {
                //AttackTurret();
                rb.velocity = Vector3.zero;
            }

        }




    }

    private void AttackedWeakPoint()
    {
        isAttackedWeakPoint = true;
    }


    private void Death()
    {
        isDead = true;
    }
}
