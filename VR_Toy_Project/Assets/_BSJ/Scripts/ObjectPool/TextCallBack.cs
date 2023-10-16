using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCallBack : MonoBehaviour
{
    // 텍스트 타입
    public TextPoolObjType textType;

    // 자동으로 반환되는 시간
    [SerializeField]
    private float textReturnTime = 2f;

    // 생성된 시점부터 더해질 시간
    [SerializeField]
    private float startTime = 0f;

    // 점점 위로 올라갈 속도
    [SerializeField]
    private float moveUpSpeed = 0.1f;

    // 텍스트 메쉬 프로
    private TextMeshProUGUI textMeshPro;
    private Color startColor;

    private void Awake()
    {
        textMeshPro = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        startColor = textMeshPro.color;
    }

    private void Update()
    {
        // 생성된 시점부터 몇 초가 지났는지 더해주기
        startTime += Time.deltaTime;

        // 총알이 반환되는 시간이 되면 반환
        if (startTime > textReturnTime)
        {
            // 오브젝트 풀로 반환
            TextObjectPool.instance.CoolObj(gameObject, textType);
            startTime = 0f;
        }

        // { 천천히 위로 올라가기
        // 현재 위치를 저장
        Vector3 currentPosition = transform.position;

        // 새 위치 계산 (위로 이동)
        currentPosition += new Vector3(0, moveUpSpeed * Time.deltaTime, 0);

        // 현재 위치를 새 위치로 설정
        transform.position = currentPosition;
        // } 천천히 위로 올라가기

        // 알파값 점점 줄이기
        float newAlpha = textMeshPro.color.a - 1 * Time.deltaTime;
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
    }

    private void OnDisable()
    {
        // 시작 시간 초기화
        startTime = 0f;

        // 알파값 초기화
        textMeshPro.color = startColor;
    }
}
