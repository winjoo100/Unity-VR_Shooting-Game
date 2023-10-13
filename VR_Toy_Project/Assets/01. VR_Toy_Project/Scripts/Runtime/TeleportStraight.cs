using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class TeleportStraight : MonoBehaviour
{
    //텔레포트를 표시할 UI
    public Transform teleportCircleUI;
    //선을 그릴 라인 렌더러
    LineRenderer Lr;
    //최초텔레포트크기
    Vector3 originScale = Vector3.one * 0.02f;

    // { 워프에 사용할 변수
    // 워프 사용 여부
    public bool isWarp = false;
    // 워프에 걸리는 시간
    public float warpTime = 0.1f;
    // 사용하고 있는 포스트 프로세싱 볼륨 컴포넌트
    public PostProcessVolume psVolume = default;
    // } 워프에 사용할 변수

    void Awake()
    {
        //시작할 때 비활성화한다.
        teleportCircleUI.gameObject.SetActive(false);
        //라인 렌더러 컴포넌트 얻어오기
        Lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        //왼쪽 컨트롤러의 One 버튼을 누르면
        if (ARAVRInput.GetDown(ARAVRInput.Button.One, ARAVRInput.Controller.LTouch))
        {
            //라인 렌더러 컴포넌트 활성화
            Lr.enabled = true;
        }
        //왼쪽 컨트롤러의 One버튼에서 손을 때면
        else if (ARAVRInput.GetUp(ARAVRInput.Button.One, ARAVRInput.Controller.LTouch))
        {
            //라인 렌더러 컴포넌트 비활성화
            Lr.enabled = false;

            if (teleportCircleUI.gameObject.activeSelf)
            {
                // 워프 기능 사용이 아닐 때 순간이동 처리
                if(isWarp == false)
                {
                    GetComponent<CharacterController>().enabled = false;
                    // 텔레포트 UI 위치로 순간이동
                    transform.position = teleportCircleUI.position + Vector3.up;
                    GetComponent<CharacterController>().enabled = true;
                }
                else
                {
                    // 워프 기능을 사용할 때는 Warp() 코루틴 호출
                    StartCoroutine(Warp());
                }

                // LEGACY:
                //GetComponent<CharacterController>().enabled = false;
                //transform.position = teleportCircleUI.position + Vector3.up;
                //GetComponent<CharacterController>().enabled = true;
            }

            // 텔레포트 UI 비활성화
            teleportCircleUI.gameObject.SetActive(false);
        }

        //왼쪽 컨트롤러의 One버튼을 누르고 있을때
        else if (ARAVRInput.Get(ARAVRInput.Button.One, ARAVRInput.Controller.LTouch))
        {
            //1. 왼쪽 컨트롤러를 기준으로 Ray를 만든다.
            Ray ray = new Ray(ARAVRInput.LHandPosition, ARAVRInput.LHandDirection);
            RaycastHit hitInfo;
            int layer = 1 << LayerMask.NameToLayer("Terrain");
            //2.Terrain만 Ray 충돌 검출한다.
            if (Physics.Raycast(ray, out hitInfo, 200, layer))
            {
                //3.Ray가 부딪힌 지점에 라인 그리기
                Lr.SetPosition(0, ray.origin);
                Lr.SetPosition(1, hitInfo.point);

                //4.Ray가 부딪힌 지점에 텔레포트 UI표시
                teleportCircleUI.gameObject.SetActive(true);
                teleportCircleUI.position = hitInfo.point;
                //텔레포트 UI가 위로 누워 있도록 방향을 설정한다.
                teleportCircleUI.forward = hitInfo.normal;
                //텔레포트 UI의 큭디가 거리에 따라 보정되도록 설정한다.
                teleportCircleUI.localScale = originScale * Mathf.Max(1f, hitInfo.distance);
            }
            else
            {
                Lr.SetPosition(0, ray.origin);
                Lr.SetPosition(1, ray.origin + ARAVRInput.LHandDirection * 200);
                teleportCircleUI.gameObject.SetActive(false);
            }
        }
    }

    //! 워프 효과를 내는 코루틴
    private IEnumerator Warp()
    {
        // 워프 느낌을 표현할 모션블러
        MotionBlur blur = default;

        // 워프 시작점 기억
        Vector3 startPos = transform.position;

        // 목적지
        Vector3 targetPos = teleportCircleUI.position + Vector3.up;

        // 워프 경과 시간
        float currentTime = 0;

        // 포스트 프로세싱에서 사용 중인 프로파일에서 모션블러 얻어오기
        psVolume.profile.TryGetSettings<MotionBlur>(out blur);

        // 워프 시작 전 블러 켜기
        blur.active = true;
        GetComponent<CharacterController>().enabled = false;

        // 경과 시간이 워프보다 짧은 시간 동안 이동 처리
        while(currentTime < warpTime)
        {
            // 경과 시간 흐르게 하기
            currentTime += Time.deltaTime;
            // 워프의 시작점에서 도착점에 도착하기 위해 워프 시간 동안 이동
            transform.position = Vector3.Lerp(startPos, targetPos, currentTime / warpTime);
            // 코루틴 대기
            yield return null;
        }

        // 텔레포트 UI 위치로 순간이동
        transform.position = teleportCircleUI.position + Vector3.up;

        // 캐릭터 컨트롤러 다시 켜기
        GetComponent<CharacterController>().enabled = true;

        // 포스트 효과 끄기
        blur.active = false;
    }
}