using System.Collections;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public float rotationSpeed = 1.5f;
    void Start()
    {

        StartCoroutine(RotateEarth());

    }

    // Update is called once per frame

    IEnumerator RotateEarth()
    {
        while (true)
        {
            gameObject.transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
            yield return null;

        }
    }
}
