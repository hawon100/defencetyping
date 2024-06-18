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
    }

    private void Start()
    {
        Init();
        GameObject ui = Managers.Resource.Instantiate("");
        hpUI = ui.GetComponent<CentralStatHPUI>();
        hpUI.InitHP(MaxHp, MaxHp);
    }

    public override void OnAttacked(int damagedHp)
    {
        base.OnAttacked(damagedHp);
        hpUI.UpdateHP(Hp);
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
