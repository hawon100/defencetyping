using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
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
        DirectMove();
        RotateObject();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        Poolable poolBullet = poolManager.Pop(bullet, transform);

        poolBullet.transform.parent = null;
        poolBullet.transform.position = transform.position;

        if (poolBullet.gameObject.GetComponent<BezierBullet>() != null) //Temp
        {
            poolBullet.gameObject.GetComponent<BezierBullet>().target = target;
            poolBullet.gameObject.GetComponent<BezierBullet>().enemyPoint = transform.position;
        }

        if (poolBullet.gameObject.GetComponent<DirectBullet>() != null)
        {
            poolBullet.gameObject.GetComponent<DirectBullet>().target = target;
        }
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
