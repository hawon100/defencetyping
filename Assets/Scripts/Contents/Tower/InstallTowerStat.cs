using UnityEngine;

public class InstallTowerStat : TowerStat
{
    public TowerStatHPUI hpUI;
    public override void Init()
    {
        if (Managers.Game.uiCanvas == null) Managers.Game.uiCanvas = GameObject.Find("TowerStatUI").transform; //Temp

        GameObject u = Managers.Resource.Instantiate(hpUI.gameObject, Managers.Game.uiCanvas);
        hpUI = u.GetComponent<TowerStatHPUI>();
        u.GetComponent<RectTransform>().localPosition = transform.position;
        hpUI.InitHP(MaxHp, Hp);
        base.Init();
    }

    public override void OnAttacked(int damagedHp)
    {
        base.OnAttacked(damagedHp);
        hpUI.UpdateHP(Hp);
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