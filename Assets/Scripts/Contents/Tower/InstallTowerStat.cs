using UnityEngine;

public class InstallTowerStat : TowerStat
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
        Managers.Resource.Destroy(this.gameObject);
        base.OnDead();
    }

    //protected virtual void OnDead(TowerStat attacker)
    //{

    //}

    public override void OnFixed(int fixHp)
    {
        base.OnFixed(fixHp);
    }
}