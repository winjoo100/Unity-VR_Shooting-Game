using System;
using System.Collections;
using System.Collections.Generic;
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
                instance_ = new GameManager();
            }

            return instance_;
        }
    }
    #endregion

    #region Variables
    // { 초기화를 위한 컴포너트들
    private UIManager uiManager = default;
    private PlayerStatus playerStatus = default;
    private BossManager bossManager = default;
    // { 초기화를 위한 컴포너트들

    // { 터렛을 관리할 리스트 
    public List<Transform> turret1List = default; 
    public List<Transform> turret2List = default; 
    public List<Transform> turret3List = default; 
    public List<Transform> turret4List = default; 
    // } 터렛을 관리할 리스트 

    // { 게임 사이클 변수
    public bool isStart = default;
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
        if(isStart == default || isStart == false) {  return; }

        // { TEST : 버튼에 할당해서 ReStart() 할 것임
        if (isEnd)
        {
            ReStart();
        }
        // } TEST : 버튼에 할당해서 ReStart() 할 것임

        uiManager.Update_HUD(CurTime, Gold);

        GetTime();
    }       // Update()


    private void Init()
    {
        uiManager = GFunc.GetRootObj("UIManager").GetComponent<UIManager>();
        ResourceManager.Instance.Init();

        isStart = false;
        isEnd = false;
        CurTime = 0f;

        // 초기 골드 
        Gold = 500;
    }       // Init()

    // ! 글로벌로 사용할 시간과, 시간에 따른 골드 수급
    private void GetTime()
    {
        CurTime += Time.deltaTime;
        GetGold_Time();
    }       // GetTime()

    // ! 1초당 획득 골드
    private void GetGold_Time()
    {
        goldTime += Time.deltaTime;
        if(goldTime >= 1f)
        {
            goldTime -= 1f;
            Gold += 5;
        }            
    }

    
    // ! 졸개 처치 시 골드 획득 (고정 10)  
    public void GetGold(int gold = 10)
    {
        Gold += gold;
    }       // GetGold();

    // ! 보스 체력 비율에 따른 골드 획득
    public void GetGold(float gold)
    {
        float maxBossHP = 1000f;
        float curBossHP = 0f;
        bossHP
            10 % 9 = 1; 
    }
       
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
