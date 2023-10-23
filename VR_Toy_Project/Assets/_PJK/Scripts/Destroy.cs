using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DestroyToDie());
    }



    IEnumerator DestroyToDie()
    {
        while (transform.localScale.x > 0 || transform.localScale.y > 0 || transform.localScale.z > 0 )
        {
            gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            Debug.Log("실행되나?");
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
