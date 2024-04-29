using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectBullet : BulletBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Move();
    }

    protected override void Move()
    {
        if (target == null)
        {
            Managers.Resource.Destroy(gameObject);
            return;
        }

        targetPos = target.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
    
        if (Measure(targetPos - transform.position, 0.1f))
        {
            target = null;
            Managers.Resource.Destroy(gameObject);
        }
    }
}
