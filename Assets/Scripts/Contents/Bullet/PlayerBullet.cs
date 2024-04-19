using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    private Vector2 moveVec; //Temp
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    public void test()
    {
        if (target == null)
        {
            Managers.Resource.Destroy(gameObject);
            return;
        }
        moveVec = (target.position - transform.position).normalized;
    }

    protected override void Update()
    {
        base.Update();
        Move();
    }

    protected override void Move()
    {
        if (target == null) return;

        //transform.Translate(moveVec * Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    protected override void Hit(GameObject hitObject)
    {
        if (hitObject.GetComponent<EnemyBase>() != null)
        {
            hitObject.GetComponent<EnemyBase>().Damage(10);
        }

        //target = null;
        //Debug.Log(transform.position);
        Managers.Resource.Destroy(gameObject);
    }
}
