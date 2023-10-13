using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLv1 : MonoBehaviour
{
    public GameObject lv1 = default;
    private GameObject player = default;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        StartCoroutine(firtswave()) ;
    }

    private IEnumerator firtswave()
    {
        Vector3 startLocation = lv1.transform.position;
        Vector3 targetLocation = player.transform.position;

        float yPosition = startLocation.y;
        float xPosition = startLocation.x;
        //시작하는시간
        float currentTime = 0f;
        //도착하는데 도달하는 시간(초)
        float finishTime = 40f;
        // 경과율
        BossManager.instance.elapsedRate = currentTime / finishTime;
        while (BossManager.instance.elapsedRate < 1)
        {
            currentTime += Time.deltaTime;
            BossManager.instance.elapsedRate = currentTime / finishTime;
            lv1.transform.position = Vector3.Lerp(startLocation, targetLocation, BossManager.instance.elapsedRate);
            // Y 위치를 고정 x위치와 z위치 고정
            Vector3 newPosition = new Vector3(
                xPosition,
                yPosition, // 고정된 Y 위치
                Mathf.Lerp(startLocation.z, targetLocation.z, BossManager.instance.elapsedRate)
            );
            lv1.transform.position = newPosition;
            yield return null;
        }

    }
}
