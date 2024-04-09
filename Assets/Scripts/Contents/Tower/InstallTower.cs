using UnityEngine;

public class InstallTower : TowerBase
{
    [SerializeField] private Define.InstallTowerType _installType;
    [SerializeField] private float curShotDelay;
    [SerializeField] private float maxShotDelay;

    protected override void Start()
    {
        
    }

    protected override void Update()
    {
        OnAttack();
    }

    protected override void OnAttack()
    {
        curShotDelay += Time.deltaTime;

        if (curShotDelay < maxShotDelay) return;



        maxShotDelay = 0;
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