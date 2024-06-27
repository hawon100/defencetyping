using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierBullet : BulletBase
{
    public float height = 5f;

    [SerializeField] private GameObject boom;
    [SerializeField] private Vector3 targetPoint;
    [SerializeField] private Define.BulletType bulletType;
    public Vector3 startPoint;

    private TrailRenderer trail; //Temp

    private float t; //Temp
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();


        targetPoint = target.position;
        ResetPos();

        trail = GetComponent<TrailRenderer>(); //Temp
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnEnable()
    {
        ResetPos();
    }

    public override void Init()
    {
        base.Init();
    }

    private void ResetPos()
    {
        t = 0;
        startPoint = transform.position;
    }

    protected override void Move()
    {
        t += Time.deltaTime;
        targetPoint = target.position;
        transform.position = Bezier(startPoint, targetPoint, height, t / speed); //fail!
    }

    private Vector3 Bezier(Vector3 startPos, Vector3 endPos, float height, float t)
    {
        Vector3 A = startPos;
        Vector3 B = endPos;

        A.y = startPos.y + height;
        B.y = endPos.y   + height;

        Vector3 X = Vector3.Lerp(startPos, A, t);
        Vector3 Y = Vector3.Lerp(A, B, t);
        Vector3 Z = Vector3.Lerp(B, endPos, t);

        Vector3 XY = Vector3.Lerp(X, Y, t);
        Vector3 YZ = Vector3.Lerp(Y, Z, t);

        return Vector3.Lerp(XY, YZ, t);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(triggerTag)) Hit();
    }

    protected override void Hit()
    {
        if (!(Vector2.Distance(transform.position, target.position) < 0.9f)) return;

        //GameObject b = Managers.Resource.Instantiate(boom, null);
        //b.transform.position = transform.position;

        if (bulletType == Define.BulletType.Enemy) target.GetComponent<EnemyStat>().Damage(1);
        if (bulletType == Define.BulletType.Tower) target.GetComponent<TowerStat>().OnAttacked(1);
        target = null;
        base.Hit();
    }
}
