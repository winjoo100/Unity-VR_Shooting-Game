using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretConsolUI : MonoBehaviour
{
    private List<GameObject> TurretList;
    private const string costTxt = "CostTxt";
    private const string uniCnttTxt = "UnitCntTxt";

    private string tempTxt = default;

    // Start is called before the first frame update
    void Start()
    {
        Init();
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

    // Update is called once per frame
    void Update()
    {

    }
}
