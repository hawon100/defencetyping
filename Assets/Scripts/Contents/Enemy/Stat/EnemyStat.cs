using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : EnemyStatBase
{
    [SerializeField] private GameObject hpPanelPrefab;
    [SerializeField] private SpriteRenderer spriteRend;
    private WaitForSeconds waitSeconds = new WaitForSeconds(0.4f);
    public override void Init()
    {
        base.Init();
    }

    public override void Damage(int value)
    {
        //GameObject ui = Managers.Resource.Instantiate(hpPanelPrefab, null);
        //Once get damage, UI show the HP Bar.
        if (hp > 1) StartCoroutine(DamagedMotion());
        base.Damage(value);
    }

    protected override void Death()
    {
        spriteRend.color = Color.white;

        //GameObject d = Managers.Resource.Instantiate("VFX/DustExplosion");
        GameObject d = Managers.Resource.Instantiate("VFX/BigExplosion");
        d.transform.position = transform.position;
        GameObject e = Managers.Resource.Instantiate("VFX/boom");
        e.transform.position = transform.position;
        e.transform.localScale = 3 * Vector2.one;

        base.Death();
    }

    private IEnumerator DamagedMotion()
    {
        spriteRend.color = Color.red;
        yield return waitSeconds;
        spriteRend.color = Color.white;
        yield return waitSeconds;
    }

    protected override void OnDisable() => base.OnDisable();
}
