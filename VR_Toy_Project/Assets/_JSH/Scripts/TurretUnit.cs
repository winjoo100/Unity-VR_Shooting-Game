using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUnit : MonoBehaviour
{
    // { 터렛 유닛이 가지고 있어야 하는 변수들
    // 터렛 이름
    protected string name = default;
    // 터렛 최대 체력
    protected int healthMax = default;
    // 터렛 현재 체력
    protected int health = default;
    // 터렛 비용
    protected int cost = default;
    // 터렛 상한
    protected int install_Limit = default;
    // 터렛 탐지 범위
    protected int range = default;
    // 터렛 발사 간격
    protected float firing_Interval = default;
    // 사용할 탄환 ID
    protected int bullet_Table_ID = default;
    // 사용할 터렛 모델
    protected string image = default;
    // 가장 가까운 목표
    protected Transform target = default;
    // 터렛 공격 준비
    protected bool isReady = false;
    // } 터렛 유닛이 가지고 있어야 하는 변수들


    //! 터렛 자신의 정보 초기화
    public virtual void Init(int health_, int range_)
    {
        // TODO: 변수 초기화 추가 
        healthMax = health_;
        health = healthMax;
        range = range_;
    }

    //! 터렛의 탐지 로직
    protected virtual void DetectTarget()
    {
        int monsterLayer_ = 1 << LayerMask.NameToLayer("Monster");
        int bossLayer_ = 1 << LayerMask.NameToLayer("Boss");

        // TODO: 보스가 쏘는 투사체 레이어 추가

        int layerMask_ = monsterLayer_ | bossLayer_;

        // 영역 안의 목표들
        Collider[] hitObjects_ = Physics.OverlapSphere(transform.position, range, layerMask_);

        // 영역 안에 목표가 존재하지 않음
        if (hitObjects_.Length <= 0)
        {
            return;
        }
        else { /* Do Nothing */ }

        // 가장 가까운 목표를 탐색하는 루프
        int closest_ = 0;
        for (int i = closest_ + 1; i < hitObjects_.Length; i++)
        {
            // 가장 가까운 목표와의 거리
            float closestDistance_ = (transform.position - hitObjects_[closest_].transform.position).magnitude;
            // 다음 목표와의 거리
            float nextDistance_ = (transform.position - hitObjects_[i].transform.position).magnitude;

            // 다음 목표가 더 가깝다면
            if (nextDistance_ < closestDistance_)
            {
                // 다음 목표의 인덱스로 교체
                closest_ = i;
            }
            else { /* Do Nothing */ }
        }

        // 탐색한 목표를 저장
        target = hitObjects_[closest_].transform;
    }       // DetectTarget()

    //! 터렛의 공격 로직
    protected virtual void AttackTarget()
    {
        // TODO: 지정된 적을 향해 공격

    }

    //! 일정 주기로 1. 목표 탐색 함수 호출 후 2. 공격 함수 호출
    protected virtual IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        DetectTarget();
        AttackTarget();
    }
}
