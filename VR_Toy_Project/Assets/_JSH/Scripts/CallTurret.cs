using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTurret : MonoBehaviour
{
    private Vector3 originScale = default;

    private void Start()
    {
        originScale = new Vector3(25, 25, 150);
    }

    private void Update()
    {
        Calling();
    }

    private void Calling()
    {
        transform.localScale += new Vector3(0, 0, -2);

        if (transform.localScale.z < 50)
        {
            transform.localScale = originScale;
        }
    }
}
