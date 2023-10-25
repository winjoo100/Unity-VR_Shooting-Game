using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretConsolUI : MonoBehaviour
{
    private List<GameObject> TurretList;
    private const string costTxt = "CostTxt";
    private const string uniCntTxt = "UnitCntTxt";

    private string tempTxt = default;

    void Start()
    {
        Init();

        for (int i = 0; i < 4; i++)
        {
            UpdateCnt(i);
        }
    }

    // ! 터렛 텍스트 초기화
    void Init()
    {
        TurretList = new List<GameObject>();
        int objName = 1300;
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = gameObject.GetChildObj(objName.ToString());
            TurretList.Add(obj);
            objName++;
        }       // loop : 1300번대 오브젝트들 캐싱해서 리스트에 삽입

        for (int i = 0; i < TurretList.Count; i++)
        {
            int index = i;
            tempTxt = JsonData.Instance.unitDatas.Unit[index].Cost.ToString();
            TurretList[i].GetChildObj(costTxt).SetTmpText(tempTxt);
        }       // loop : 터렛 코스트 정보 텍스트에 삽입
    }       // Init()

    //! JSH: 갯수 갱신
    public void UpdateCnt(int name_)
    {
        switch (name_)
        {
            case 1300:
                tempTxt = string.Format("{0} / {1}", GameManager.Instance.turretLv1_List.Count, JsonData.Instance.unitDatas.Unit[0].Install_Limit.ToString());
                TurretList[0].GetChildObj(uniCntTxt).SetTmpText(tempTxt);
                break;
            case 1301:
                tempTxt = string.Format("{0} / {1}", GameManager.Instance.turretLv2_List.Count, JsonData.Instance.unitDatas.Unit[1].Install_Limit.ToString());
                TurretList[1].GetChildObj(uniCntTxt).SetTmpText(tempTxt);
                break;
            case 1302:
                tempTxt = string.Format("{0} / {1}", GameManager.Instance.turretLv3_List.Count, JsonData.Instance.unitDatas.Unit[2].Install_Limit.ToString());
                TurretList[2].GetChildObj(uniCntTxt).SetTmpText(tempTxt);
                break;
            case 1303:
                tempTxt = string.Format("{0} / {1}", GameManager.Instance.turretLv4_List.Count, JsonData.Instance.unitDatas.Unit[3].Install_Limit.ToString());
                TurretList[3].GetChildObj(uniCntTxt).SetTmpText(tempTxt);
                break;
        }

    }
}
