using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Temp

public class CenteralTowerStat : TowerStat
{
    //[SerializeField] private Text CentralTowerHP; //Temp
    [SerializeField] private CentralStatHPUI hpUI;
    public override void Init()
    {
        base.Init();
        hpUI.InitHP(MaxHp, MaxHp);
    }

    private void Start()
    {
        Init();
    }

    public override void OnAttacked(int damagedHp)
    {
        hpUI.UpdateHP(Hp - damagedHp);
        base.OnAttacked(damagedHp);
    }

    protected override void OnDead()
    {
        Managers.Wave.isWave = false;
    }

    //protected virtual void OnDead(TowerStat attacker)
    //{

    //}

    public override void OnFixed(int fixHp)
    {
        base.OnFixed(fixHp);
    }
}
