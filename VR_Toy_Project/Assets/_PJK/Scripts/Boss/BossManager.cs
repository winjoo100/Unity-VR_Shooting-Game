using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public float elapsedRate = default;
    public float currentTime = default;
    public float gametime = default;
    public float spawn = default;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        spawn += Time.deltaTime;
        gametime += Time.deltaTime;
        //Debug.Log(gametime);
    }
}
