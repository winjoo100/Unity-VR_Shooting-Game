using UnityEngine;

public class KillAllCollider : MonoBehaviour
{
    private Boss boss;
    private GameObject monster;
    //터렛
    public GameObject turret = default;
    private void Awake()
    {
        boss = GetComponentInParent<Boss>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turret"))
        {
            turret = other.gameObject;
            turret.gameObject.SetActive(false);
        }

    }
}
