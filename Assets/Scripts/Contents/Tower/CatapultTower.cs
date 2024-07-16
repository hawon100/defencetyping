using System.Collections;
using UnityEngine;

public class CatapultTower : TowerBase
{
    [SerializeField] private Define.InstallTowerType _installType;

    [Header("Bullet")]
    [SerializeField] private BezierBullet2 bullet;

    [Header("Auto Attack")]
    [SerializeField] private float cooltime;
    [SerializeField] private float delayTime;

    [Header("Catapult")]
    [SerializeField] private Animator catapult;
    [SerializeField] private Transform shotPoint;

    private float timerate;

    private WaitForSeconds animeDelay;

    private readonly int attackHash = Animator.StringToHash("Attack");
    private readonly WaitForSeconds waiting = new(1f);

    private TowerStat towerStat;

    protected override void Start()
    {
        animeDelay = new(delayTime);

        towerStat = GetComponent<TowerStat>();

        GameObject t = Managers.Resource.Instantiate("TargetSign");
        t.SetActive(false);
        t.transform.parent = this.transform;
        targetSign = t.GetComponent<TargetSign>();
    }

    protected override void Update()
    {
        if (!Managers.Wave.isWave) return; //KILL SWITCH!

        timerate += Time.deltaTime;

        if (timerate < cooltime) return;

        timerate = 0;
        OnAttack();
    }

    protected override void OnAttack()
    {
        Detected();

        if (_target == null) return;

        StartCoroutine(AttackCoroutine());
    }

    private TargetSign targetSign;

    private IEnumerator AttackCoroutine()
    {
        if (_target)
        {
            targetSign.gameObject.SetActive(true);
            targetSign.transform.position = _target.position;
            targetSign.tower = this.gameObject;
            targetSign.target = _target;
        }
        else
        {
            targetSign.gameObject.SetActive(false);
        }

        yield return animeDelay;

        catapult.SetTrigger(attackHash);

        GameObject b = Managers.Resource.Instantiate(bullet.gameObject, null);
        b.transform.position = shotPoint.parent.position; //Temp
        BulletBase s = b.GetComponent<BulletBase>();
        s.Init();
        s.damage = towerStat.Attack;
        s.target = _target;
        s.triggerTag = _targetTag;

        yield return waiting;

        StopCoroutine(AttackCoroutine());
    }

    protected override void AdjustLevel()
    {

    }

    protected override void OnSkill()
    {

    }

    protected override void TowerFixed()
    {

    }

    protected override void OnDamaged()
    {

    }

    protected override void Detected() => base.Detected();
    protected override void OnDrawGizmos() => base.OnDrawGizmos();

    public override void Attack() //Temp
    {
        OnAttack();
    }
}
