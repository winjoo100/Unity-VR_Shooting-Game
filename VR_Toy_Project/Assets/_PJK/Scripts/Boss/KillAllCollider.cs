using UnityEngine;

public class KillAllCollider : MonoBehaviour
{
    private BossMoving Boss;
    private GameObject monster;
    //터렛
    public GameObject turret = default;
    private void Awake()
    {
        Boss = GetComponentInParent<BossMoving>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Turret"))
        {
            turret = other.gameObject;
            turret.gameObject.SetActive(false);
        }

    }
}
