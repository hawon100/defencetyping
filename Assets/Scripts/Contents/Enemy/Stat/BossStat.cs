using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStat : EnemyStatBase
{
    [SerializeField] private BarController hpBar;
    [SerializeField] private SpriteRenderer spriteRend;
    private WaitForSeconds waitSeconds = new WaitForSeconds(0.4f);

    public override void Init()
    {
        //if (Managers.Game.uiCanvas == null) Managers.Game.uiCanvas = GameObject.Find("TowerStatUI").transform; //Temp

        //Transform canvas = Managers.Game.uiCanvas;
        Transform canvas = GameObject.Find("WordUI").transform;
        GameObject bar = Managers.Resource.Instantiate("UI/BossBar", canvas);

        hpBar = bar.GetComponent<BarController>();
        hpBar.SetPosition(new Vector2(0, 500f));
        hpBar.transform.SetAsFirstSibling();
        hpBar.Init(maxHp);
        base.Init();

        Debug.Log(Managers.Game.uiCanvas);
    }

    public override void Damage(int value)
    {
        hpBar.Updated(hp - value);
        //GameObject ui = Managers.Resource.Instantiate(hpPanelPrefab, null);
        //Once get damage, UI show the HP Bar.
        if (hp > 1) StartCoroutine(DamagedMotion());
        base.Damage(value);
    }

    protected override void Death()
    {
        spriteRend.color = Color.white;

        if (isDeath) StartCoroutine(ExplosionDeath());
        Managers.Resource.Destroy(hpBar.gameObject);
        UserStat.Gold += gold;
        //Managers.Wave.GameEnd();

        base.Death();
    }

    private IEnumerator ExplosionDeath()
    {
        GameObject d = Managers.Resource.Instantiate("VFX/BigExplosion");
        d.transform.position = transform.position;
        yield return waitSeconds;

        for (int i = -1; i < 2; i++)
        {
            GameObject e = Managers.Resource.Instantiate("VFX/boom");
            e.transform.position = transform.position + i * Vector3.one;
            e.transform.localScale = 3 * Vector2.one;
            yield return waitSeconds;
        }

        StopCoroutine(ExplosionDeath());
    }
    
    private IEnumerator DamagedMotion()
    {
        spriteRend.color = Color.red;
        yield return waitSeconds;
        spriteRend.color = Color.white;
        yield return waitSeconds;

        StopCoroutine(DamagedMotion());
    }

    protected override void OnEnable() => base.OnEnable();

    protected override void OnDisable() => base.OnDisable();
}
