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
        for (int i = 0; i < 5; i++)
        {
            Managers.Resource.Instantiate(playerBullet.gameObject, transform);
        }
    }

    protected override void Update()
    {
        if (isDetected) Detected();
    }

    protected override void OnAttack()
    {
        if (_target == null) return;

        curShotDelay += Time.deltaTime;

        if (curShotDelay < maxShotDelay) return;

        playerBullet.target = _target;

        //Debug.Log(_target);
        GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, transform.parent = null);

        b.transform.parent = transform;
        b.transform.position = transform.position;

        curShotDelay -= maxShotDelay;
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