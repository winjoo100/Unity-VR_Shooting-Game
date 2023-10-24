using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    private GameObject hudCanvas = default;
    private GameObject StartCanvas = default;
    private GameObject startBtn = default; 
    private GameObject quitBtn = default;
    private GameObject reStartBtn = default;
    private GameObject gameOverTxt = default;
    private GameObject resultTimeTxt = default;
    private GameObject logoImg = default;
    private GameObject StartBtnTxt = default;

    private Slider slider = default;
    private GameObject timerTxt = default;
    private GameObject goldTxt = default;
    private GameObject hpTxt = default;

    private Boss boss = default;
    private PlayerStatus playerStat = default;
    
    // UI에 표시할 텍스트 
    private string timeFormat = default;
    private string hpFormat = default;
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
        // { 컴퍼넌트 
        boss = GFunc.GetRootObj("Boss").GetComponent<Boss>();
        playerStat = GFunc.GetRootObj("Player").GetComponent<PlayerStatus>();
        // } 컴퍼넌트 
        
        // { HUD Canvas 
        hudCanvas = GFunc.GetRootObj("PlayerHUDCanvas");
        StartCanvas = GFunc.GetRootObj("GameStartCanvas");        
        timerTxt = hudCanvas.GetChildObj("TimerTxt");
        slider = hudCanvas.GetChildObj("BossHPSlider").GetComponent<Slider>();
        goldTxt = hudCanvas.GetChildObj("GoldTxt");
        hpTxt = hudCanvas.GetChildObj("UI_PlayerHP");
        // } HUD Canvas 

        // { Start Canvas
        startBtn = StartCanvas.GetChildObj("StartButton");
        quitBtn = StartCanvas.GetChildObj("QuitButton");
        reStartBtn = StartCanvas.GetChildObj("ReStartButton");
        gameOverTxt = StartCanvas.GetChildObj("GameOver");
        resultTimeTxt = StartCanvas.GetChildObj("TimeTxt");
        logoImg = StartCanvas.GetChildObj("LogoImg");
        StartBtnTxt = StartCanvas.GetChildObj("Text (TMP)");
        StartBtnTxt.SetTmpText("게임 시작");

        reStartBtn.GetComponent<Button>().onClick.AddListener(OnReStartButton);
        startBtn.GetComponent<Button>().onClick.AddListener(OnStartButton);
        quitBtn.GetComponent<Button>().onClick.AddListener(OnQuitButtion);
        // } Start Canvas

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

        hpFormat = string.Format("HP " + "{0} / {1}", playerStat.curHp.ToString("D3"), playerStat.maxHp.ToString("D3"));
        hpTxt.SetTmpText(hpFormat);
        // } HUD Text 변경

        slider.value = ((float)boss.CurHP / (float)boss.MaxHp);

    }   // UpdateHUD()

    public void ChangeUI_GameOver()
    {
        gameOverTxt.SetActive(true);
        reStartBtn.SetActive(true);

        startBtn.SetActive(false);
        logoImg.SetActive(false);
        resultTimeTxt.SetActive(false);
    }

    public void ChangeUI_GameWin()
    {
        resultTimeTxt.SetTmpText(timeFormat);        
        resultTimeTxt.SetActive(true);
        reStartBtn.SetActive(true);

        startBtn.SetActive(false);
        logoImg.SetActive(false);
        gameOverTxt.SetActive(false);
    }

    // ! 게임 시작 버튼 클릭시 동작
    public void OnStartButton()
    {
        bool isStart_ = GameManager.Instance.GameStart();       
        StartCanvas.SetActive(!isStart_);
    }       // OnStartButton()

    // ! 게임 재시작 버튼 클릭시 동작
    public void OnReStartButton()
    {
        GameManager.Instance.ReStart();
    }

    // ! 게임 종료 버튼 클릭시 동작
    public void OnQuitButtion()
    {        
        GameManager.Instance.GameQuit();
    }       // OnQuitButtion()

}
