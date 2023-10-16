using Meta.WitAi;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GunLazerPointer : MonoBehaviour
{
    // 어떤 손인지 판단
    public bool isLeftHand = default;

    // 크로스 헤어
    public Canvas crosshairCan;

    // 레이저 포인트를 발사할 라인 렌더러
    LineRenderer lineRenderer;

    // 레이저 포인터의 최대 거리
    [SerializeField]
    private float lrMaxDistance = 200f;

    // 레이저 포인터의 칼라
    public Color lazerColor;

    private void Awake()
    {
        // 라인 렌더러 셋팅
        lineRenderer = GetComponent<LineRenderer>();
        lazerColor.a = 0.5f;
        lineRenderer.startColor = lazerColor;
        lineRenderer.endColor = lazerColor;

        // 크로스헤어 색상 변경
        crosshairCan.GetComponentInChildren<Image>().color = lazerColor;
    }

    private void Update()
    {
        //특정 layer만 raycast제외하기 (1)
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Bullet"));  // Everything에서 Bullet 레이어만 제외하고 충돌 체크함

        if (isLeftHand)
        {
            // 왼쪽 컨트롤러 기준으로 Ray를 만든다.
            Ray ray = new Ray(BSJVRInput.LHandPosition, BSJVRInput.LHandDirection);
            RaycastHit hitInfo;

            // 충돌이 있다면?
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            {
                // Ray가 부딪힌 지점에 라인 그리기
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, hitInfo.point);

                // 부딪힌 지점에 크로스 헤어 그리기
                crosshairCan.transform.position = hitInfo.point;
            }

            // 충돌이 없다면?
            else
            {
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, ray.origin + BSJVRInput.LHandDirection * lrMaxDistance);

                crosshairCan.transform.position = ray.origin + BSJVRInput.LHandDirection * lrMaxDistance;
            }
        }       // if : 왼쪽 핸드 기준으로 레이저 포인터 만들기

        else
        {
            // 오른쪽 컨트롤러 기준으로 Ray를 만든다.
            Ray ray = new Ray(BSJVRInput.RHandPosition, BSJVRInput.RHandDirection);
            RaycastHit hitInfo;

            // 충돌이 있다면?
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
            {
                // Ray가 부딪힌 지점에 라인 그리기
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, hitInfo.point);

                // 부딪힌 지점에 크로스 헤어 그리기
                crosshairCan.transform.position = hitInfo.point;
            }

            // 충돌이 없다면?
            else
            {
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, ray.origin + BSJVRInput.RHandDirection * lrMaxDistance);

                crosshairCan.transform.position = ray.origin + BSJVRInput.RHandDirection * lrMaxDistance;
            }
        }       // else : 오른쪽 핸드 기준으로 레이저 포인터 만들기
    }
}
