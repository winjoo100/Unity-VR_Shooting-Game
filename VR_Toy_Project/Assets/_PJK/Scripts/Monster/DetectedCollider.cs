using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedCollider : MonoBehaviour
{
    private Monsters monsters;
    private GameObject monster;

    private void Awake()
    {
        monsters = GetComponentInParent<Monsters>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turret"))
        {
            monsters.turret = other.gameObject;
            monsters.isFindTurret = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Turret"))
        {
            monsters.turret = null;
            monsters.isFindTurret = false;
        }
    }
}
