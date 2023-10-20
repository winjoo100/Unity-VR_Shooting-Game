using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance_ = default;

    public static GameManager Instance
    {
        get
        {
            if (instance_ == null || instance_ == default)
            {
                instance_ = GFunc.GetRootObj("GameManager").GetComponent<GameManager>();
            }

            return instance_;
        }
    }
    #endregion

    #region Variables
    // { 초기화를 위한 컴포너트들
    private UIManager uiManager = default;
    private PlayerStatus playerStatus = default;
    private Boss boss = default;
    // { 초기화를 위한 컴포너트들

    [Header ("Turret List")]
    [Space]
    // { 터렛을 관리할 리스트 
    public List<Transform> turretLv1_List = default;
    public List<Transform> turretLv2_List = default;
    public List<Transform> turretLv3_List = default;
    public List<Transform> turretLv4_List = default;
    // } 터렛을 관리할 리스트 

    [Header("GameCycle boolean")]
    [Space]
    // { 게임 사이클 변수
    public bool isStart = true;
    public bool isEnd = default;
    // } 게임 사이클 변수

    // { HUD 변수
    public float CurTime { get; private set; }
    public int Gold { get; private set; }

    private float goldTime = default;

    

    // } HUD 변수
    #endregion

    private void Awake()
    {
        Init();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == default || isStart == false) { return; }

        // { TEST : 버튼에 할당해서 ReStart() 할 것임
        if (isEnd)
        {
            ReStart();
        }
        // } TEST : 버튼에 할당해서 ReStart() 할 것임

        uiManager.Update_HUD(CurTime, Gold);

        Timer();

    }       // Update()


    private void Init()
    {
        uiManager = GFunc.GetRootObj("UIManager").GetComponent<UIManager>();
        boss = GFunc.GetRootObj("Boss").GetComponent<Boss>();

        ResourceManager.Instance.Init();

        isStart = false;
        isEnd = false;
        CurTime = 0f;

        // { JSH 리스트 할당
        turretLv1_List = new List<Transform>();
        turretLv2_List = new List<Transform>();
        turretLv3_List = new List<Transform>();
        turretLv4_List = new List<Transform>();
        // } JSH 리스트 할당

        // 초기 골드 
        Gold = 500;
    }       // Init()

    // ! 글로벌로 사용할 타이머, 시간에 따른 골드 수급
    private void Timer()
    {
        CurTime += Time.deltaTime;
        GetGold_Time();
    }       // Timer()

    // ! 1초당 획득 골드
    private void GetGold_Time()
    {
        goldTime += Time.deltaTime;
        if (goldTime >= 1f)
        {
            goldTime -= 1f;
            Gold += JsonData.Instance.economyDatas.Economy[1].Gold_Gain;
        }
    }       // GetGold_Time()


    // ! 졸개 처치 시 골드 획득 (고정 10)  
    public void GetGold_Monster()
    {
        Gold += JsonData.Instance.economyDatas.Economy[3].Gold_Gain;
    }       // GetGold_Monster();

    // ! 보스 체력 비율에 따른 골드 획득
    public void GetGold_Boss()
    {                       
        Gold += JsonData.Instance.economyDatas.Economy[2].Gold_Gain;
    }       // GetGold_Boss()


    public bool GameStart()
    {
        isStart = true;
        return isStart;
    }       // GameStart()

    public void ReStart()
    {
        Init();
        isStart = true;
    }       // ReStart()

    public void GameQuit()
    {
        Application.Quit();
    }       // QameQuit()
}
