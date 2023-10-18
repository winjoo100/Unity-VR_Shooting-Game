using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    #region Singleton
    private static ResourceManager instance_ = default;

    public static ResourceManager Instance
    {
        get
        {
            if (instance_ == null || instance_ == default)
            {
                instance_ = new ResourceManager();
            }

            return instance_;
        }
    }
    #endregion

    #region CSV List
    /** 리스트로 묶어서 관리하는게 좋을 것 같으나, 알아보기 어려울 가능성이 있으므로
    *  각각의 문서마다 리스트를 따로 관리하도록 함
    */    
    public List<Dictionary<string, object>> Boss_Data { get; private set; }
    public List<Dictionary<string, object>> Boss_Skill { get; private set; } 
    public List<Dictionary<string, object>> Bullet { get; private set; } 
    public List<Dictionary<string, object>> Economy { get; private set; }    
    public List<Dictionary<string, object>> Icon { get; private set; } 
    public List<Dictionary<string, object>> Monster{ get; private set; } 
    public List<Dictionary<string, object>> Monster_Spawn { get; private set; } 
    public List<Dictionary<string, object>> Unit { get; private set; } 
    public List<Dictionary<string, object>> User_data { get; private set; } 
    public List<Dictionary<string, object>> Weapon { get; private set; }
    #endregion
        
    public void Init()
    {
        Boss_Data = CSVReader.Read("Boss_Data");
        Boss_Skill = CSVReader.Read("Boss_Skill");
        Bullet = CSVReader.Read("Bullet");
        Economy = CSVReader.Read("Economy");
        Icon = CSVReader.Read("Icon");
        Monster = CSVReader.Read("Monster");
        Monster_Spawn = CSVReader.Read("Monster_Spawn");
        Unit = CSVReader.Read("Unit");
        User_data = CSVReader.Read("User_data");
        Weapon = CSVReader.Read("Weapon");
    }       // Init()   
}
