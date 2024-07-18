using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralTower : TowerBase
{
    [Header("Bullet")]
    [SerializeField] private BezierBullet2 towerBullet;

    [Header("Skill")]
    [SerializeField] private GameObject zenWave;

    [Header("Boom Effect")]
    [SerializeField] private GameObject boom;

    private float timerate;
    private const float rotationTolerance = 1f; // Tolerance in degrees for aiming accuracy

    //Attack Enabled() -> InstallTowerStat.Init(); 

    protected override void Start()
    {
        _range = 200f;
        for (int i = 0; i < 3; i++)
        {
            //GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, null);
            //Managers.Resource.Destroy(b);
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
        Debug.Log("Attacked!");
        GameObject m = Managers.Resource.Instantiate(boom, null);
        m.transform.position = transform.position;

        GameObject b = Managers.Resource.Instantiate(towerBullet.gameObject, null);
        b.transform.position = transform.position;
        BezierBullet2 s = b.GetComponent<BezierBullet2>();
        s.Init();
        s.target = _target;
        _target = null;
    }

    protected override void AdjustLevel()
    {

    }

    protected override void OnSkill()
    {
        GameObject w = Managers.Resource.Instantiate("Skills/WaveEffect");
        w.transform.position = transform.position;
        ZenWave z = w.GetComponentInChildren<ZenWave>();
        z.damage = 10;
        z.StableStart();
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
        Debug.Log("Skill() in child was activated");
        OnSkill();
    }
}
