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

            GameObject b = Managers.Resource.Instantiate(bezierBullet.gameObject, transform.parent = null);

            b.transform.parent = null;
            b.transform.position = transform.position;
        }
        else
        {
            directBullet.target = target;

            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);

            b.transform.parent = null;
            b.transform.position = transform.position;
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
