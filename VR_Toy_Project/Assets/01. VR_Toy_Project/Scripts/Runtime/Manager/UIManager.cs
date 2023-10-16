using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject canvas = default;
    //[SerializeField]
    //private GameObject startBtn = default;
    public GameObject timerTxt = default;
    public GameObject goldTxt = default;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        canvas = GFunc.GetRootObj("Canvas");
        //startBtn = canvas.GetChildObj("StartBtn");
        timerTxt = canvas.GetChildObj("TimerTxt");
        goldTxt = canvas.GetChildObj("GoldTxt");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Update_HUD(float curTime_, int gold_)
    {
        {
            // { 시간을 분 / 초 로 나눔
            int min = (((int)curTime_ / 60));
            int sec = ((int)curTime_ % 60);
            // } 시간을 분 / 초 로 나눔

            string timeFormat = string.Format("Timer {0} : {1}", min.ToString("D2"), sec.ToString("D2"));
            timerTxt.SetTmpText(timeFormat);
            goldTxt.SetTmpText(gold_.ToString());
        }       // UpdateHUD()


    }
}
