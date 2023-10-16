using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null)
        {
            // REGACY:
            // transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);

            // TEST:
            Quaternion newRotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
            transform.rotation = newRotation;
        }
    }
}
