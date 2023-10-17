using Meta.WitAi.Lib;
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

    // { 게임 사이클 변수
    [SerializeField]
    private bool isStart = default;
    [SerializeField]    
    private bool isEnd = default;
    // } 게임 사이클 변수


    // { HUD 변수
    public float CurTime { get; private set; }
    public int Gold { get; private set; }
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
        if(isEnd)
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
        Gold = 0;
    }       // Init()

    private void GetTime()
    {
        CurTime += Time.deltaTime;
        // TEST : 추후 골드 얻는 곳에서 추가 시킬 것
        //Gold += 1;

    }       // GetTime()



    public void GameStart()
    {
        isStart = true;
    }       // GameStart()

    public void ReStart()
    {
        Init();
        isStart = true;
    }       // ReStart()

}
