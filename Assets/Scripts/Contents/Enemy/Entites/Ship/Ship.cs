using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [Header("Bullet")]
    public DirectBullet directBullet;

    private Rigidbody2D rb2d;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 3; i++)
        {
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
            Managers.Resource.Destroy(b);
        }
    }

    protected override void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }


    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
        BulletBase s = b.GetComponent<DirectBullet>();
        s.Init();
        s.target = target;
        b.transform.position = transform.position;

        Detected();

        if (target == null) target = Managers.Game.target;
    }

    protected override void Detected()
    {
        base.Detected();
    }

    protected override void Move()
    {
        LookAt();

        if (!isMove)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }

        Detected();

        rb2d.velocity = moveSpeed * Trace(transform.position, target.position);

        if (rb2d.velocity.sqrMagnitude <= 0.1f ||
            isDistance(transform.position, target.position, stopDistance))
        {
            rb2d.velocity = Vector2.zero;
            isMove = false;
        }
    }

    protected override void LookAt()
    {
        base.LookAt();
    }
}
