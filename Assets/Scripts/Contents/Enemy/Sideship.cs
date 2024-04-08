using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sideship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
    [Header("Bullets")]
    public GameObject bezierBullet; //private Temp

    private Vector3 spriteRotation;

    private float t = 90f;

    protected override void Awake()
    {
        base.Awake();
        RandomInt();
    }

    protected override void Start()
    {
        base.Start();
        isMove = true;
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
        if (!isMove)
        {
            Poolable farBullet = poolManager.Pop(bezierBullet, transform);

            farBullet.transform.parent = null;
            farBullet.transform.position = transform.position;

            if (farBullet.gameObject.GetComponent<BezierBullet>() != null) //Temp
            {
                farBullet.gameObject.GetComponent<BezierBullet>().target = target;
                farBullet.gameObject.GetComponent<BezierBullet>().enemyPoint = transform.position;
            }
        }
    }

    protected override void DirectMove()
    {
        if (!isDistance(transform.position, target.position, 8))
            if (isMove) base.DirectMove();
        else
        {
            t -= Time.deltaTime;
            if (t <= 0)
            {
                isMove = false;
            }
        }
    }

    private void RotateObject()
    {
        spriteRotation.z = Gaze(transform.position, target.position) - t;

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
