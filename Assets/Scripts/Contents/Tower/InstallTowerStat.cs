using UnityEngine;

public class InstallTowerStat : TowerStat
{
    public TowerStatHPUI hpUI;
    public override void Init()
    {
        if (Managers.Game.uiCanvas == null) Managers.Game.uiCanvas = GameObject.Find("TowerStatUI").transform; //Temp

        GameObject u = Managers.Resource.Instantiate("UI/TowerHP/TowerHP", Managers.Game.uiCanvas);
        hpUI = u.GetComponent<TowerStatHPUI>();
        //hpUI.MoveUI(new Vector2(4, 4));
        hpUI.SetUI(towerPos);
        hpUI.InitHP(MaxHp, MaxHp);
        base.Init();
    }

    public override void OnAttacked(int damagedHp)
    {
        hpUI.UpdateHP(Hp - damagedHp);
        base.OnAttacked(damagedHp);
    }

    protected override void OnDead()
    {
        Managers.Resource.Destroy(this.gameObject);
        Managers.Resource.Destroy(hpUI.gameObject);
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