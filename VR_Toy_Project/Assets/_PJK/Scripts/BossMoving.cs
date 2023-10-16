using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static GrabObject;

public class BossMoving : MonoBehaviour
{
    
    public GameObject monsterSpawner = default;
    private GameObject boss =default;
    private GameObject player =default;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_BossMove());
        
        boss   = BossManager.instance.boss;
        player = BossManager.instance.player;
    }

    private IEnumerator _BossMove()
    {
        Vector3 startLocation = boss.transform.position;
        Vector3 targetLocation = player.transform.position;

        float yPosition = startLocation.y;
        //시작하는시간
        BossManager.instance.currentTime = 0f;
        //도착하는데 도달하는 시간(초)
        float finishTime = 900f;
        // 경과율
        BossManager.instance.elapsedRate = BossManager.instance.currentTime / finishTime;
        while (BossManager.instance.elapsedRate < 1)
        {
            BossManager.instance.currentTime += Time.deltaTime;
            BossManager.instance.elapsedRate = BossManager.instance.currentTime / finishTime;
            boss.transform.position = Vector3.Lerp(startLocation, targetLocation, BossManager.instance.elapsedRate);
            // Y 위치를 고정 x위치와 z위치 고정
            Vector3 newPosition = new Vector3(
                Mathf.Lerp(startLocation.x, targetLocation.x, BossManager.instance.elapsedRate),
                yPosition, // 고정된 Y 위치
                Mathf.Lerp(startLocation.z, targetLocation.z, BossManager.instance.elapsedRate)
            );
            boss.transform.position = newPosition;
            yield return null;
        }

    }

}
