using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
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
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        //transform.Translate((target.position - transform.position).normalized * Time.deltaTime * speed);
    }

    protected override void Hit(GameObject hitObject)
    {
        if (hitObject.GetComponent<EnemyBase>() != null)
        {
            hitObject.GetComponent<EnemyBase>().Damage(10);
        }

        base.Hit(hitObject);
    }
}
