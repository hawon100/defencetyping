using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenteralTowerStat : TowerStat
{
    public override void Init()
    {
        base.Init();
    }

    public override void OnAttacked(int damagedHp)
    {
        base.OnAttacked(damagedHp);
    }

    protected override void OnDead()
    {

    }

    //protected virtual void OnDead(TowerStat attacker)
    //{

    //}

    public override void OnFixed(int fixHp)
    {
        base.OnFixed(fixHp);
    }
}
