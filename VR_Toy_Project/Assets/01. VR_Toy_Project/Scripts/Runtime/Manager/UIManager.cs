using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject canvas = default;
    [SerializeField]
    private GameObject startBtn = default;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        canvas = GFunc.GetRootObj("Canvas");
        startBtn = canvas.GetChildObj("StartBtn");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
