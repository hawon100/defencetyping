using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaBullet : BulletBase
{
    // Bezier 곡선의 시작점, 중간 제어점
    [Header("Bezier")]
    [HideInInspector] public Vector3 startPoint;
    public Vector3 controlPoint;
    [HideInInspector] public Vector3 endPoint;

    private float t;

    //[Header("Effect")]
    //[SerializeField] private GameObject boom;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        startPoint = transform.position;
        t = 0.0f;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        if (!target) return;
        //{
        //    Managers.Resource.Destroy(gameObject);
        //    return;
        //}

        t += Time.deltaTime * speed;

        endPoint = target.position;
        transform.position = CalculateBezierPoint(t, startPoint, controlPoint, endPoint);
    }

    protected Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0; // (1-t)^2 * p0
        p += 2 * u * t * p1; // 2 * (1-t) * t * p1
        p += tt * p2; // t^2 * p2

        return p;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower")) Hit();
    }

    protected override void Hit()
    {
        if (!(Vector2.Distance(transform.position, target.position) < 0.9f)) return;

        //GameObject b = Managers.Resource.Instantiate(boom, null);
        //b.transform.position = transform.position;

        target.GetComponent<TowerStat>().OnAttacked(1);
        target = null;
        base.Hit();
    }
}
