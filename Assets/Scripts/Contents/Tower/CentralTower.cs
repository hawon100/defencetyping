using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralTower : TowerBase
{
    [SerializeField] private PlayerBullet playerBullet;

    [Header("Skill")]
    [SerializeField] private GameObject zenWave;

    [Header("Boom Effect")]
    [SerializeField] private GameObject boom;

    private float timerate;
    private const float rotationTolerance = 1f; // Tolerance in degrees for aiming accuracy

    //Attack Enabled() -> InstallTowerStat.Init(); 

    protected override void Start()
    {
        _range = 50f;
        for (int i = 0; i < 3; i++)
        {
            GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, null);
            Managers.Resource.Destroy(b);
        }
    }

    protected override void OnAttack()
    {
        Detected();

        if (_target == null) return;

        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        yield return null;

        GameObject m = Managers.Resource.Instantiate(boom, null);
        m.transform.position = transform.position;

        GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, null);
        BulletBase s = b.GetComponent<BulletBase>();
        s.Init();
        s.target = _target;
        b.transform.position = transform.position;
        _target = null;
    }

    protected override void AdjustLevel()
    {

    }

    protected override void OnSkill()
    {
        GameObject w = Managers.Resource.Instantiate(zenWave, null);
        w.transform.position = transform.position;
    }

    protected override void TowerFixed()
    {

    }

    protected override void OnDamaged()
    {

    }

    protected override void OnDrawGizmos() => base.OnDrawGizmos();

    public override void Attack() //Temp
    {
        OnAttack();
    }

    public override void Skill()
    {
        OnSkill();
    }
}
