using UnityEngine;
using UnityEngine.UI;

public class InstallTowerStat : TowerStat
{
    public TeamData teamData;
    public TowerStatHPUI hpUI;

    public override void Init()
    {
        base.Init();

        for (int i = 0; i < Managers.Data.CharacterDict.Count; i++)
        {
            _level = Managers.Data.CharacterDict[i].level;
            _hp = Managers.Data.CharacterDict[i].hp;
            _maxHp = Managers.Data.CharacterDict[i].hp;
            _attack = Managers.Data.CharacterDict[i].attack;
        }

        if (Managers.Game.uiCanvas == null) Managers.Game.uiCanvas = GameObject.Find("TowerStatUI").transform; //Temp
        GameObject u = Managers.Resource.Instantiate("UI/TowerHP/TowerHP", Managers.Game.uiCanvas);
        hpUI = u.GetComponent<TowerStatHPUI>();
        //hpUI.MoveUI(new Vector2(4, 4));
        hpUI.SetUI(towerPos, Managers.Game.uiCanvas.GetComponent<Canvas>());
        hpUI.InitHP(MaxHp, MaxHp);
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