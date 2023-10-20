using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    public static JsonData Instance;

    public TextAsset bossData_Json;
    public TextAsset bossSkill_Json;
    public TextAsset bullet_Json;
    public TextAsset economy_Json;
    public TextAsset monster_Json;
    public TextAsset monsterSpawn_Json;
    public TextAsset unit_Json;
    public TextAsset weapon_Json;

    public All_BossDatas bossDatas;
    public All_BossSkills bossSkillDatas;
    public All_Bullets bulletDatas;
    public All_EconomyDatas economyDatas;
    public All_MonsterDatas monsterDatas;
    public All_MonsterSpawnDatas monsterSpawnDatas;
    public All_UnitDatas unitDatas;
    public All_WeaponDatas weaponDatas;

    private void Awake()
    {
        // 스태틱으로 데이터 저장하기
        Instance = this;

        // Json 파일 파싱
        bossDatas = JsonUtility.FromJson<All_BossDatas>(bossData_Json.text);
        bossSkillDatas = JsonUtility.FromJson<All_BossSkills>(bossSkill_Json.text);
        bulletDatas = JsonUtility.FromJson<All_Bullets>(bullet_Json.text);
        economyDatas = JsonUtility.FromJson<All_EconomyDatas>(economy_Json.text);
        monsterDatas = JsonUtility.FromJson<All_MonsterDatas>(monster_Json.text);
        monsterSpawnDatas = JsonUtility.FromJson<All_MonsterSpawnDatas>(monsterSpawn_Json.text);
        unitDatas = JsonUtility.FromJson<All_UnitDatas>(unit_Json.text);
        weaponDatas = JsonUtility.FromJson<All_WeaponDatas>(weapon_Json.text);

        // 잘 파싱 되었는지 확인
        foreach (var data in bossDatas.Boss_Data)
        {
        }

        foreach (var data in bossSkillDatas.Boss_Skill)
        {
        }

        foreach (var data in bulletDatas.Bullet)
        {
        }

        foreach (var data in economyDatas.Economy)
        {
        }

        foreach (var data in monsterDatas.Monster)
        {
        }

        foreach (var data in monsterSpawnDatas.Monster_Spawn)
        {
        }

        foreach (var data in unitDatas.Unit)
        {
        }

        foreach (var data in weaponDatas.Weapon)
        {
        }

    }
}

#region 보스 데이터
[System.Serializable]
public class All_BossDatas
{
    // Json 파일 이름이 Boss이다.
    public Boss_Data[] Boss_Data;
}

[System.Serializable]
public class Boss_Data
{
    public int ID;
    public string Description;
    public int Hp;
    public float Arrive_Time;
    public float DeadSizeX;
    public float DeadSizeY;
    public float DeadSizeZ;
    public float DeadInstance;
    public int WeaknessF;
    public int WeaknessL;
    public int WeaknessR;
    public float Cooltime;
    public int Skill_1;
    public int Skill2;
    public int Skill;
}
#endregion

#region 보스 스킬
[System.Serializable]
public class All_BossSkills
{
    // Json 파일 이름이 Boss_Skill이다.
    public BossSkill[] Boss_Skill;
}

[System.Serializable]
public class BossSkill
{
    public int ID;
    public string Description;
    public int Hp;
    public int Att;
    public float Speed;
    public int Amount_Min;
    public int Amount_max;
}
#endregion

#region 총알 데이터
[System.Serializable]
public class All_Bullets
{
    // Json 파일 이름이 Bullet이다.
    public BulletData[] Bullet;
}

[System.Serializable]
public class BulletData
{
    public int ID;
    public string Description;
    public int Att;
    public float Bullet_Speed;
    public float Life_Time;
    public float Size;
    public float Cri_Chance;
    public float Cri_Damege;
}
#endregion

#region 재화
[System.Serializable]
public class All_EconomyDatas
{
    // Json 파일 이름이 Economy이다.
    public EconomyData[] Economy;
}

[System.Serializable]
public class EconomyData
{
    public int ID;
    public string Description;
    public int Method;
    public int Gold_Gain;
    public float Gold_Time;
    public float Boss_Hp;
}
#endregion

#region 몬스터
[System.Serializable]
public class All_MonsterDatas
{
    // Json 파일 이름이 Monster이다.
    public MonsterData[] Monster;
}

[System.Serializable]
public class MonsterData
{
    public int ID;
    public string Description;
    public int Type;
    public int HP;
    public int Att;
    public float Att_Speed;
    public int Explosion_Damage;
    public float Speed;
    public int PlayerRange;
    public int UnitRange;
    public float Att_Range;
    public int Ex_Range;
}
#endregion

#region 몬스터 스폰
[System.Serializable]
public class All_MonsterSpawnDatas
{
    // Json 파일 이름이 Monster_Spawn이다.
    public MonsterSpawnData[] Monster_Spawn;
}

[System.Serializable]
public class MonsterSpawnData
{
    public int ID;
    public string Description;
    public int Spawn_Condition;
    public int Spawn_Interval;
    public int Monster;
    public int Amount;
    public float Distance;
}
#endregion

#region 유닛
[System.Serializable]
public class All_UnitDatas
{
    // Json 파일 이름이 Unit이다.
    public UnitData[] Unit;
}

[System.Serializable]
public class UnitData
{
    public int ID;
    public string Name;
    public string Description;
    public int Install_Limit;
    public int Cost;
    public int HP;
    public int Range;
    public float Firing_Interval;
    public int Bullet_Table_ID;
}
#endregion

#region 무기
[System.Serializable]
public class All_WeaponDatas
{
    // Json 파일 이름이 Weapon이다.
    public WeaponData[] Weapon;
}

[System.Serializable]
public class WeaponData
{
    public int ID;
    public string Description;
    public float Firing_Interval;
    public int Cost;
}
#endregion