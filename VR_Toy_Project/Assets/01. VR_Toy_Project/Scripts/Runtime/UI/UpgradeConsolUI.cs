using System.Collections.Generic;
using UnityEngine;

public class UpgradeConsolUI : MonoBehaviour
{
    private List<GameObject> UpgradeList;
    private const string costTxt = "CostTxt";
    private const string unableTxt = "UnableTxt";

    private string tempTxt = default;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // ! 무기 텍스트 초기화
    void Init()
    {
        UpgradeList = new List<GameObject>();
        int objName = 1001;
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = gameObject.GetChildObj(objName.ToString());
            UpgradeList.Add(obj);
            objName++;
        }       // loop : 1000번대 오브젝트들 캐싱해서 리스트에 삽입

        for(int i = 0; i < UpgradeList.Count; i++)
        {
            int index = i + 1;
            tempTxt = JsonData.Instance.weaponDatas.Weapon[index].Cost.ToString();
            UpgradeList[i].GetChildObj(costTxt).SetTmpText(tempTxt);
        }       // loop : 무기 코스트 정보 텍스트에 삽입
    }       // Init()

    // Update is called once per frame
    void Update()
    {
        
    }
}
