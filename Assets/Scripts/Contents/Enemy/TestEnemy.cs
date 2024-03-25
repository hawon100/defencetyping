using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBase
{
    [SerializeField] private Transform trans; //Temp
    public GameObject bullet; //private Temp

    private Vector3 spriteRotation;

    protected override void Awake()
    {
        base.Awake();
        RandomInt();
    }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Update()
    {
        base.Update();
        RotateObject();
    }

    protected override void Attack()
    {
        Poolable poolBullet = poolManager.Pop(bullet, transform);

        poolBullet.transform.parent = null;
        poolBullet.transform.position = transform.position;
        poolBullet.gameObject.GetComponent<BezierBullet>().target = target;
        poolBullet.gameObject.GetComponent<BezierBullet>().enemyPoint = transform.position;
    }

    protected override void DirectMove()
    {
        base.DirectMove();
    }

    private void RotateObject()
    {
        spriteRotation.z = Gaze(transform.position, target.position) - 90f;

        transform.rotation = Quaternion.Euler(spriteRotation);
    }

    protected override void Death()
    {
        base.Death();
    } 

    private void RandomInt()
    {
        distance = Random.Range(5f, 8f);
    }
}
