using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLv1 : MonoBehaviour
{
    public GameObject lv1 = default;
    public GameObject player = default;
    public GameObject[] monsterSpawner = default;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_normalMove());
    }

    private IEnumerator _normalMove()
    {
        Vector3 startLocation = lv1.transform.position;
        Vector3 targetLocation = player.transform.position;

        float yPosition = startLocation.y;
        //시작하는시간
        BossManager.instance.currentTime = 0f;
        //도착하는데 도달하는 시간(초)
        float finishTime = 20f;
        // 경과율
        BossManager.instance.elapsedRate = BossManager.instance.currentTime / finishTime;
        while (BossManager.instance.elapsedRate < 1)
        {
            BossManager.instance.currentTime += Time.deltaTime;
            BossManager.instance.elapsedRate = BossManager.instance.currentTime / finishTime;
            lv1.transform.position = Vector3.Lerp(startLocation, targetLocation, BossManager.instance.elapsedRate);
            // Y 위치를 고정 x위치와 z위치 고정
            Vector3 newPosition = new Vector3(
                Mathf.Lerp(startLocation.x, targetLocation.x, BossManager.instance.elapsedRate),
                yPosition, // 고정된 Y 위치
                Mathf.Lerp(startLocation.z, targetLocation.z, BossManager.instance.elapsedRate)
            );
            lv1.transform.position = newPosition;
            yield return null;
        }

    }
}
