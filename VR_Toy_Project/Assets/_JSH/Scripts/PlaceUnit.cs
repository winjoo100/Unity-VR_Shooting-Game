using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUnit : MonoBehaviour
{
    // 배치할 유닛 ID
    private int turretID = default;
    // 배치할 유닛 프리팹 테스트용
    public GameObject placeUnitPrefab = default;
    // 배치할 유닛 프리팹들
    public GameObject[] turretPrefabs = default;
    // 유닛 배치 UI
    public Transform placeUnitUI = default;
    // 선을 그릴 라인 렌더러
    private LineRenderer lineRenderer = default;
    // 버튼 클릭용 클래스
    PlayerStatus playerStatus = default;

    private void Awake()
    {
        // 시작할 때 비활성화
        placeUnitUI.gameObject.SetActive(false);

        // 라인 렌더러 컴포넌트 얻어오기
        lineRenderer = GetComponent<LineRenderer>();

        // 라인 렌더러 비활성화
        lineRenderer.enabled = false;

        // 버튼 클릭 클래스 받아오기
        playerStatus = FindObjectOfType<PlayerStatus>();
    }

    private void OnEnable()
    {
        // 라인 렌더러 컴포넌트 활성화
        lineRenderer.enabled = true;
    }

    private void Update()
    {
        // 왼쪽 컨트롤러의 One 버튼에서 손을 떼면
        if (BSJVRInput.GetUp(BSJVRInput.Button.Two, BSJVRInput.Controller.LTouch))
        {
            // 라인 렌더러 컴포넌트 비활성화
            lineRenderer.enabled = false;

            if (placeUnitUI.gameObject.activeSelf)
            {
                // 유닛 배치 UI 위치에 유닛 생성
                SpawnUnit();
                // 유닛 배치 UI의 좌표 변경
                placeUnitUI.transform.position = Vector3.up * -100;
            }

            // 유닛 배치 UI 비활성화
            placeUnitUI.gameObject.SetActive(false);

            // 배치가 끝났으니 모드 전환
            playerStatus.mode = Mode.ShotMode;
            playerStatus.ModeSwap();
        }

        // 왼쪽 컨트롤러를 기준으로 Ray를 만든다
        Ray ray_ = new Ray(BSJVRInput.LHandPosition, BSJVRInput.LHandDirection);
        RaycastHit hitInfo_ = default;
        int layer_ = 1 << LayerMask.NameToLayer("Terrain");

        // Terrain만 Ray 충돌 검출
        if (Physics.Raycast(ray_, out hitInfo_, 200f, layer_))
        {
            // Ray가 부딪힌 지점에 라인 그리기
            lineRenderer.SetPosition(0, ray_.origin);
            lineRenderer.SetPosition(1, hitInfo_.point);
            // Ray가 부딪힌 지점에 유닛 배치 UI 표시
            placeUnitUI.gameObject.SetActive(true);
            placeUnitUI.position = hitInfo_.point;
            // 유닛 배치 UI의 Head가 위로 향하도록 방향 설정
            placeUnitUI.up = hitInfo_.normal;
            // 유닛 배치 UI의 크기가 거리에 따라 보정되도록 설정
            //placeUnitUI.localScale = originScale * Mathf.Max(1, hitInfo.distance);
        }
        else
        {
            // Ray 충돌이 발생하지 않으면 선이 Ray 방향으로 그려지도록 처리
            lineRenderer.SetPosition(0, ray_.origin);
            lineRenderer.SetPosition(1, ray_.origin + BSJVRInput.LHandDirection * 200f);
            // 유닛 배치 UI는 화면에서 비활성화
            placeUnitUI.gameObject.SetActive(false);
        }
    }       // Update()

    //! 터렛 생성
    private void SpawnUnit()
    {
        // TODO: ID에 맞는 프리팹 찾아서 소환해야함
        Transform unit_ = Instantiate(placeUnitPrefab).transform;

        unit_.position = placeUnitUI.position;
        unit_.rotation = placeUnitUI.rotation;
        unit_.localScale = placeUnitUI.localScale;
    }

    //! 터렛 ID SET
    public void SetID(int idNum_)
    {
        turretID = idNum_;
    }

    //! TODO: 설치 후 게임매니져의 터렛 리스트에 추가
    
}
