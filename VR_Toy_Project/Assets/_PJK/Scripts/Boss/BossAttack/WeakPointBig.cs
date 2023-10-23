using System;
using System.Collections;
using UnityEngine;

public class WeakPointBig : MonoBehaviour, IDamageable
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
            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        else 
        {
            myMat = weakOn;
            transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        }
    }

    public void OnDamage(int damage)
    {
        if (myMat == weakOn)
        {
            boss.OnDamage((int)(damage * 1.3f));
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
        int reviveTime=UnityEngine.Random.Range(3, 7);

        yield return new WaitForSeconds(reviveTime);
        isLive = true;
        
    }
}
