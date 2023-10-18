using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public Boss boss;

    public float weakpointhp = 100f;

    private void Update()
    {
        if (weakpointhp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        boss.weakActiveCount--;
    }
}
