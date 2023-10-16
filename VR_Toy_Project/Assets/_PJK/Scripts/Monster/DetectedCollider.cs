using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedCollider : MonoBehaviour
{
    private MonsterLv1 monsterLv1;
    private GameObject monster;

    private void Awake()
    {
        monsterLv1 = GetComponentInParent<MonsterLv1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.CompareTag("Turret"))
        {
            monsterLv1.turret = other.gameObject;
            monsterLv1.isFindTurret = true;
        }
    }
}
