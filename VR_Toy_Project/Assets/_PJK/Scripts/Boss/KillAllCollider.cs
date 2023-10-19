using UnityEngine;

public class KillAllCollider : MonoBehaviour
{
    //터렛
    [SerializeField]
    private GameObject turret;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Turret"))
        {
            turret = other.gameObject;
            Destroy(turret);
        }

    }
}
