using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : EnemyBase
{
    [Header("Bomb")]
    public DirectBullet directBullet;

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < 3; i++)
        {
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
            Managers.Resource.Destroy(b);
        }
    }

    protected override void Start()
    {
        base.Start();
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack() //First : Detected(), if no target : target set to centraltower
    {
        if (target != null)
            target = Managers.Game.target;

        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
        BulletBase s = b.GetComponent<BulletBase>();
        s.target = target;
        s.Init();
        b.transform.position = transform.position;
    }

    protected override void Detected()
    {
        base.Detected();
    }

    protected override void Move()
    {
        if (!isMove) return;

        LookAt();

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    protected override void LookAt()
    {
        base.LookAt();
    }
}
