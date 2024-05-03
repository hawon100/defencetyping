using UnityEngine;

public class InstallTower : TowerBase
{
    [SerializeField] private Define.InstallTowerType _installType;
    [SerializeField] private float curShotDelay;
    [SerializeField] private float maxShotDelay;

    [SerializeField] private PlayerBullet playerBullet;

    [Header("Auto Attack")]
    [SerializeField] private float cooltime;

    private float timerate;

    //private bool isDetected = true;

    protected override void Start()
    {
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
    }

    protected override void OnAttack()
    {
        if (_target != null)
        {
            GameObject b = Managers.Resource.Instantiate(playerBullet.gameObject, null);
            BulletBase s = b.GetComponent<BulletBase>();
            s.target = _target;
            s.Init();
            b.transform.position = transform.position;
            _target = null;
        }
        else
        {
            Detected();
        }
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