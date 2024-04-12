using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
    [Header("Bullets")]
    public BezierBullet bezierBullet; //private Temp
    public DirectBullet directBullet; //private Temp

    private Vector3 spriteRotation;

    protected override void Awake()
    {
        base.Awake();
        RandomInt();
        //BulletPool(bezierBullet, 10);
        //BulletPool(directBullet, 10);
    }

    protected override void Start()
    {
        base.Start();
        //CreateBullet();
        //Managers.Resource.
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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        if (isMove)
        {
            bezierBullet.target = target;
            bezierBullet.enemyPoint = transform.position;

            Managers.Resource.Instantiate(bezierBullet.gameObject, transform.parent = null);
        }
        else
        {
            directBullet.target = target;
            //directBullet.gameObject.transform.parent = null;
            //directBullet.gameObject.transform.position = transform.position;
            //bezierBullet를 변경하고 bezierBullet.gameObject를 Pop한다.

            Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isMove = false;
        }
    }
}
