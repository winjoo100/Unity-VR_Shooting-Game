using System;
using System.Collections;
using UnityEngine;

public class WeakPointSmall : MonoBehaviour, IDamageable
{
    public Boss boss;
    private Material myMat;
    public Material weakOn;
    public Material weakOut;
    private bool isLive = false;


    public void Start()
    {
        myMat = GetComponent<Material>();
    }


    private void Update()
    {
        if (isLive == true)
        {
            myMat = weakOut;
        }
        else
        {
            myMat = weakOn;
        }
    }

    public void OnDamage(int damage)
    {
        if (myMat == weakOn)
        {
            boss.OnDamage((int)(damage * 2f));
            StartCoroutine(ActiveWeakpoint());
        }
        else if (myMat == weakOut)
        {

            boss.OnDamage(damage);
        }
    }

    IEnumerator ActiveWeakpoint()
    {
        isLive = false;
        int reviveTime = UnityEngine.Random.Range(1, 5);

        yield return new WaitForSeconds(reviveTime);
        isLive = true;

    }
}
