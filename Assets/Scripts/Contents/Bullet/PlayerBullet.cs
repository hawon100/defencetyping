using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    private Vector2 moveVec; //Temp

    public override void Init()
    {
        base.Init();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    //public void test()
    //{
    //    if (target == null)
    //    {
    //        Managers.Resource.Destroy(gameObject);
    //        return;
    //    }
    //    moveVec = (target.position - transform.position).normalized;
    //}

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
        //transform.Translate(moveVec * Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);

        if (Measure(targetPos - transform.position, 0.05f)) //This one has the Problem
        {
            base.Hit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hit();
        }
    }

    protected override void Hit()
    {
        target.gameObject.GetComponent<EnemyStat>().Damage(1);
        target = null;
        base.Hit();
    }

    //Erase And Use isDistance Function.
    //protected override void Hit(GameObject hitObject)
    //{
    //    if (hitObject.GetComponent<EnemyBase>() != null)
    //    {
    //        hitObject.GetComponent<EnemyBase>().Damage(10);
    //    }

    //    target = null;
    //    Managers.Resource.Destroy(gameObject);
    //}
}
