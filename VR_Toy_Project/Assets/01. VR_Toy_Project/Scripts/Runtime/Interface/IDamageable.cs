using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    // ! 해당 함수를 구현하고 내용을 채운다. 
    void OnDamage(int damage);   

    // ! 사용예시 
    //float curHp = 0f;

    //public void OnDamage(float damage)
    //{
    //    if (curHp >= damage)
    //    {
    //        curHp -= damage;
    //    }
    //    else
    //    {
    //        // TODO : Die() 관련 함수 실행
    //    }


    //}

}
