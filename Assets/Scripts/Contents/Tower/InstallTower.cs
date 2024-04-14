using UnityEngine;

public class InstallTower : TowerBase
{
    [SerializeField] private Define.InstallTowerType _installType;
    [SerializeField] private float curShotDelay;
    [SerializeField] private float maxShotDelay;

    [SerializeField] private PlayerBullet playerBullet;

    private bool isDetected = true;

    protected override void Start()
    {

    }

    protected override void Update()
    {
        if (isDetected) Detected();
    }

    protected override void OnAttack()
    {
        curShotDelay += Time.deltaTime;

        if (curShotDelay < maxShotDelay) return;

        if (_target == null) return;

        playerBullet.target = _target;

        GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, transform.parent = null);

        b.transform.parent = null;
        b.transform.position = transform.position;

        curShotDelay -= maxShotDelay;

        playerBullet.target = null;
        _target = null;
    }

    protected override void AdjustLevel()
    {

    }

    protected override void Skill()
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
}