using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierBullet : BulletBase
{
    public float height = 5f;

    [SerializeField] private Vector3 targetPoint;
    public Vector3 enemyPoint;

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

        trail = GetComponent<TrailRenderer>(); //Temp
    }

    protected override void Update()
    {
        base.Update();
        Move();
    }

    private void OnEnable()
    {
        ResetPos();
    }

    private void ResetPos()
    {
        t = 0;
        enemyPoint = transform.position;
    }

    protected override void Move()
    {
        t += Time.deltaTime;
        transform.position = Bezier(enemyPoint, targetPoint, height, t / speed); //fail!
    }

    protected override void Hit()
    {
        base.Hit();
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
}
