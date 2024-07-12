using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Temp

public class CenteralTowerStat : TowerStat
{
    //[SerializeField] private Text CentralTowerHP; //Temp
    [SerializeField] private BarController hpUI;

    private WaitForSeconds waitSeconds = new WaitForSeconds(0.4f);
    private SpriteRenderer spriteRenderer;
    public override void Init()
    {
        base.Init();
        hpUI.InitHP(MaxHp);
    }

    private void Start()
    {
        Init();

        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    public override void OnAttacked(int damagedHp)
    {
        hpUI.UpdateHP(Hp - damagedHp);
        base.OnAttacked(damagedHp);
        if (Hp > 1) StartCoroutine(DamagedMotion());
    }

    private IEnumerator DamagedMotion()
    {
        spriteRenderer.color = Color.red;
        yield return waitSeconds;
        spriteRenderer.color = Color.white;
        yield return waitSeconds;

        StopCoroutine(DamagedMotion());
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
        hpUI.UpdateHP(Hp + fixHp);
        base.OnFixed(fixHp);
    }
}
