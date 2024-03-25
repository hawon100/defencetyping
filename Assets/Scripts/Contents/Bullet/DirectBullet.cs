using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectBullet : BulletBase
{
    public float speed;

    public Transform target; //Temp
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
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    protected override void Hit()
    {

        base.Hit();
    }
}
