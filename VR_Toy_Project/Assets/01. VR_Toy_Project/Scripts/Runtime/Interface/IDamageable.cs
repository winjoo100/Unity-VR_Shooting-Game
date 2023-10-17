using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable<T> where T : class
{
    // ! 해당 함수를 구현하고 내용을 채운다. 
    void OnDamage(T t, float damage);
    //{    
    //    if(hp >= damage)
    //    {
    //        hp -= damage;
    //    }
    //    else
    //    {
    //        // TODO : Die() 관련 함수들 여기서 실행
    //    }
    //}
}
