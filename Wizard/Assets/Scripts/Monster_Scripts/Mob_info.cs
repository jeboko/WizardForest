using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mob_info
{
    // 몬스터 스탯 정보
    public string MobName;
    public GameObject MobObject;
    public float Hp;
    public float Atk;
    public float weight;

    public Mob_info(Mob_info mob_Info)
    {
        this.MobName = mob_Info.MobName;
        this.MobObject = mob_Info.MobObject;
        this.Hp = mob_Info.Hp;
        this.Atk = mob_Info.Atk;
        this.weight = mob_Info.weight;
    }
}
