using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Temp

public class CenteralTowerStat : TowerStat
{
    [SerializeField] private Text CentralTowerHP; //Temp
    public override void Init()
    {
        base.Init();
    }

    private void Start()
    {
        Init();
        TextUpdate_Temp();
    }

    public override void OnAttacked(int damagedHp)
    {
        base.OnAttacked(damagedHp);
        TextUpdate_Temp();
    }

    protected override void OnDead()
    {
        Managers.Wave.isWave = false;
    }

    public void TextUpdate_Temp()
    {
        CentralTowerHP.text = "HP : " + Hp;
    }

    //protected virtual void OnDead(TowerStat attacker)
    //{

    //}

    public override void OnFixed(int fixHp)
    {
        base.OnFixed(fixHp);
    }
}
