using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLv3 : MonoBehaviour
{
    public GameObject lv3 = default;
    private GameObject player = default;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(thirdwave());
    }

    private IEnumerator thirdwave()
    {
        Vector3 startLocation = lv3.transform.position;
        Vector3 targetLocation = player.transform.position;

        float yPosition = startLocation.y;
        //시작하는시간
        float currentTime = 0f;
        //도착하는데 도달하는 시간(초)
        float finishTime = 20f;
        // 경과율
        BossManager.instance.elapsedRate = currentTime / finishTime;


        while (BossManager.instance.elapsedRate < 1)
        {
            currentTime += Time.deltaTime;
            BossManager.instance.elapsedRate = currentTime / finishTime;
            lv3.transform.position = Vector3.Lerp(startLocation, targetLocation, BossManager.instance.elapsedRate);
            // Y 위치를 고정 x위치와 z위치 고정
            Vector3 newPosition = new Vector3(
                Mathf.Lerp(startLocation.x, targetLocation.x, BossManager.instance.elapsedRate),
                yPosition, // 고정된 Y 위치
                Mathf.Lerp(startLocation.z, targetLocation.z, BossManager.instance.elapsedRate)
            );
            lv3.transform.position = newPosition;
            yield return null;
        }

    }
}
