using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    private GameObject HUDCanvas = default;
    private GameObject StartCanvas = default;
    private GameObject startBtn = default; 
    private GameObject quitBtn = default;

    private GameObject timerTxt = default;
    private GameObject goldTxt = default;

    // UI에 표시할 타이머 텍스트 
    private string timeFormat = default;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    // ! UI 요소 캐싱 및 초기화
    public void Init()
    {
        HUDCanvas = GFunc.GetRootObj("PlayerHUDCanvas");
        StartCanvas = GFunc.GetRootObj("GameStartCanvas");
        startBtn = StartCanvas.GetChildObj("StartButton");
        quitBtn = StartCanvas.GetChildObj("QuitButton");

        timerTxt = HUDCanvas.GetChildObj("TimerTxt");
        goldTxt = HUDCanvas.GetChildObj("GoldTxt");

        startBtn.GetComponent<Button>().onClick.AddListener(OnStartButton);
        startBtn.GetComponent<Button>().onClick.AddListener(OnQuitButtion);

    }       // Init()

    // ! Player HUD 업데이트 
    public void Update_HUD(float curTime_, int gold_)
    {

        // { 시간을 분 / 초 로 나눔
        int min = (((int)curTime_ / 60));
        int sec = ((int)curTime_ % 60);
        // } 시간을 분 / 초 로 나눔

        // { HUD Text 변경
        timeFormat = string.Format("{0} : {1}", min.ToString("D2"), sec.ToString("D2"));
        timerTxt.SetTmpText(timeFormat);
        goldTxt.SetTmpText(gold_.ToString());
        // } HUD Text 변경

    }   // UpdateHUD()

    // ! 게임 시작 버튼 클릭시 동작
    public void OnStartButton()
    {
        bool isStart_ = GameManager.Instance.GameStart();       
        StartCanvas.SetActive(!isStart_);
    }

    public void OnQuitButtion()
    {
        GameManager.Instance.GameQuit();
    }

}
