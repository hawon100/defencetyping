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

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        //transform.Translate((target.position - transform.position).normalized * Time.deltaTime * speed);
    }

    protected override void Hit(GameObject hitObject)
    {

        base.Hit(hitObject);
    }
}
