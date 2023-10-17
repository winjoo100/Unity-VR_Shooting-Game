using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject HUDCanvas = default;
    private GameObject StartCanvas = default;
    //[SerializeField]
    private GameObject startBtn = default;
    public GameObject timerTxt = default;
    public GameObject goldTxt = default;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        HUDCanvas = GFunc.GetRootObj("PlayerHUDCanvas");
        StartCanvas = GFunc.GetRootObj("GameStartCanvas");
        startBtn = StartCanvas.GetChildObj("StartButton");

        timerTxt = HUDCanvas.GetChildObj("TimerTxt");
        goldTxt = HUDCanvas.GetChildObj("GoldTxt");

    }




    // Update is called once per frame
    void Update()
    {

    }

    // ! Player HUD 업데이트 
    public void Update_HUD(float curTime_, int gold_)
    {

        // { 시간을 분 / 초 로 나눔
        int min = (((int)curTime_ / 60));
        int sec = ((int)curTime_ % 60);
        // } 시간을 분 / 초 로 나눔

        // { HUD Text 변경
        string timeFormat = string.Format("{0} : {1}", min.ToString("D2"), sec.ToString("D2"));
        timerTxt.SetTmpText(timeFormat);
        goldTxt.SetTmpText(gold_.ToString());
        // } HUD Text 변경

    }   // UpdateHUD()

    // ! 게임 시작 버튼 클릭시 동작
    public void OnStartButton()
    {

    }

    public void OnDamage()
    {

    }

}
