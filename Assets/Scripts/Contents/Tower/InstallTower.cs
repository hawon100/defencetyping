using UnityEngine;
using System.Collections;

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
    private const float rotationTolerance = 1f; // Tolerance in degrees for aiming accuracy

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
        if (!Managers.Wave.isWave) return; //KILL SWITCH!

        timerate += Time.deltaTime;

        if (timerate < cooltime) return;

        timerate = 0;
        OnAttack();
    }

    private void CannonMove()
    {


        Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
        cannon.rotation = Quaternion.Slerp(cannon.rotation, targetQuaternion, rotSpeed * Time.deltaTime);

        // Check if the cannon is aimed within tolerance
        if (Quaternion.Angle(cannon.rotation, targetQuaternion) <= rotationTolerance)
        {
            timerate += Time.deltaTime;

            if (timerate < cooltime) return;
            
            timerate = 0;
            OnAttack();
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
        bool isRotate = true;

        while (isRotate)
        {
            Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, targetPos) - 90f);
            cannon.rotation = Quaternion.Slerp(cannon.rotation, targetQuaternion, rotSpeed * Time.deltaTime); 

            if (Quaternion.Angle(cannon.rotation, targetQuaternion) <= 0.1f) isRotate = false;

            yield return null;
        }

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