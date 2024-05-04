using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accordship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
    [Header("Bullets")]
    public BezierBullet bezierBullet; //private Temp
    public int bulletCount;

    private Vector3 spriteRotation;

    private bool isAttack = true;

    protected override void Awake()
    {
        base.Awake();
        RandomInt();
        //BulletPool(bezierBullet, bulletCount * 3);
    }

    protected override void Start()
    {
        base.Start();
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
        if (!isMove && isAttack)
        {
            StartCoroutine(BulletAttack());
        }
    }

    IEnumerator BulletAttack()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            bezierBullet.height = Random.Range(-3, 3);
            bezierBullet.target = target;
            bezierBullet.enemyPoint = transform.position;
            Managers.Resource.Instantiate(bezierBullet.gameObject, transform.parent = null); ;

            //Poolable farBullet = poolManager.Pop(bezierBullet, transform);

            //farBullet.transform.parent = null;
            //farBullet.transform.position = transform.position;

            //if (farBullet.gameObject.GetComponent<BezierBullet>() != null) //Temp
            //{
            //    farBullet.gameObject.GetComponent<BezierBullet>().target = target;
            //    farBullet.gameObject.GetComponent<BezierBullet>().height = Random.Range(-3, 3);
            //    farBullet.gameObject.GetComponent<BezierBullet>().enemyPoint = transform.position;
            //}

            yield return new WaitForSeconds(0.2f);
        }
        isAttack = false;
    }

    protected override void Move()
    {
        base.Move();
    }

    private void RotateObject()
    {
        spriteRotation.z = Gaze(transform.position, target.position) - 90f;

        transform.rotation = Quaternion.Euler(spriteRotation);
    }

    private void RandomInt()
    {
        distance = Random.Range(5f, 8f);
    }
}
