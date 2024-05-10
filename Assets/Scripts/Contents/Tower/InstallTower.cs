using UnityEngine;

public class InstallTower : TowerBase
{
    [SerializeField] private Define.InstallTowerType _installType;
    [SerializeField] private float curShotDelay;
    [SerializeField] private float maxShotDelay;

    [SerializeField] private PlayerBullet playerBullet;

    [Header("Auto Attack")]
    [SerializeField] private float cooltime;

    [Header("Cannon")]
    [SerializeField] private float rotSpeed = 5f;
    [SerializeField] private Transform cannon;
    [SerializeField] private Transform shotPoint;

    private float timerate;

    //private bool isDetected = true;

    //Attack Enabled() -> InstallTowerStat.Init(); 

    protected override void Start()
    {
        rotSpeed = 5f;
        for (int i = 0; i < 3; i++)
        {
            GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, null);
            Managers.Resource.Destroy(b); 
        }
    }

    protected override void Update()
    {
        if (timerate >= cooltime)
        {
            timerate = 0;
            OnAttack();
        }
        else
        {
            timerate += Time.deltaTime;
        }
        CannonMove();
    }

    private void CannonMove()
    {
        Detected();
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
        cannon.rotation = Quaternion.Slerp(cannon.rotation, targetQuaternion, rotSpeed * Time.deltaTime);
    }

    protected override void OnAttack()
    {
        Detected();

        if (_target == null) return;
        else targetPos = Vector2.zero;
        
        GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, null);
        BulletBase s = b.GetComponent<BulletBase>();
        s.Init();
        s.target = _target;
        b.transform.position = shotPoint.position;
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

    public override void Attack() //Temp
    {
        OnAttack();
    }
}