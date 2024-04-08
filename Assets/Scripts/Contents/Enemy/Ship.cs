using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
    [Header("Bullets")]
    public GameObject bezierBullet; //private Temp
    public GameObject directBullet; //private Temp

    private Vector3 spriteRotation;

    protected override void Awake()
    {
        base.Awake();
        RandomInt();
    }

    protected override void Start()
    {
        base.Start();
        //CreateBullet();
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
        Poolable farBullet = poolManager.Pop(bezierBullet, transform);
        Poolable closeBullet = poolManager.Pop(directBullet, transform);

        if (isDistance(transform.position, target.position, 10))
        {
            closeBullet.transform.parent = null;
            closeBullet.transform.position = transform.position;
        }
        else
        {
            farBullet.transform.parent = null;
            farBullet.transform.position = transform.position;
        }

        if (farBullet.gameObject.GetComponent<BezierBullet>() != null) //Temp
        {
            farBullet.gameObject.GetComponent<BezierBullet>().target = target;
            farBullet.gameObject.GetComponent<BezierBullet>().enemyPoint = transform.position;
        }

        if (closeBullet.gameObject.GetComponent<DirectBullet>() != null)
        {
            closeBullet.gameObject.GetComponent<DirectBullet>().target = target;
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
