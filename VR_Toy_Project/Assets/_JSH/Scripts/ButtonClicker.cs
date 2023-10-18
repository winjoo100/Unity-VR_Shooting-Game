using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  LEGACY
public enum Mode
{
    ShotMode,
    PlaceMode,
}

public class ButtonClicker : MonoBehaviour
{
    // 모드 전환할 Shot 클래스 
    public Shot_BSJ shot = default;
    // 모드 전환할 PlaceUnit 클래스
    public PlaceUnit placeUnit = default;
    // 모드
    public Mode mode = default;

    private void Awake()
    {
        // 기본 모드는 Shot모드
        mode = Mode.ShotMode;
        // 모드 적용
        ModeSwap();
    }

    private void Update()
    {
        // 왼쪽 컨트롤러를 기준으로 Ray를 만든다
        Ray ray_ = new Ray(BSJVRInput.LHandPosition, BSJVRInput.LHandDirection);
        RaycastHit hitInfo_ = default;
        int layer_ = 1 << LayerMask.NameToLayer("Water");

        // Terrain만 Ray 충돌 검출
        if (Physics.Raycast(ray_, out hitInfo_, 200f, layer_))
        {
            Debug.Log("레이 충돌 검출");

            // 버튼이랑 부딪혔는지 체크
            if (hitInfo_.collider.gameObject.GetComponent<Button>() != null)
            {
                // 버튼에는 총알을 발사하지 않는다
                shot.enabled = false;

                // 버튼의 OnClick에 설정된 함수를 실행
                hitInfo_.collider.gameObject.GetComponent<Button>().onClick.Invoke();
            }

            // 어떤 버튼인지 컴포넌트로 체크
            if (hitInfo_.collider.gameObject.GetComponent<Upgrade01>() != null)
            {
                if (BSJVRInput.GetUp(BSJVRInput.Button.One, BSJVRInput.Controller.LTouch))
                {
                    // 모드 변경
                    mode = Mode.ShotMode;
                    ModeSwap();

                    // 버튼의 기능 실행
                    hitInfo_.transform.GetComponent<Upgrade01>().UpgradeWeapon();
                }
            }
            else if (hitInfo_.collider.gameObject.GetComponent<TurretButton01>() != null)
            {
                Debug.Log("배치 버튼");
                if (BSJVRInput.GetUp(BSJVRInput.Button.One, BSJVRInput.Controller.LTouch))
                {
                    Debug.Log("클릭");
                    // 모드 변경
                    mode = Mode.PlaceMode;
                    ModeSwap();

                    // 버튼의 기능 실행
                    hitInfo_.transform.GetComponent<TurretButton01>().PlaceTurret();
                }
            }
        }
    }

    //! Mode에 맞춰 스크립트를 키고 끄는 함수
    public void ModeSwap()
    {
        switch (mode)
        {
            // 사격 활성화, 배치 비활성화
            case Mode.ShotMode:
                shot.enabled = true;
                placeUnit.enabled = false;
                break;
            // 배치 활성화, 사격 비활성화
            case Mode.PlaceMode:
                placeUnit.enabled = true;
                shot.enabled = false;
                break;
            // 이상한 값이 들어갔을 경우 Log 표시
            default:
                Debug.Log("Mode가 이상함");
                break;
        }
    }
}

 */