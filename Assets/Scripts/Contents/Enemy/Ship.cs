using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [SerializeField] private Transform trans; //Temp (Name!)
    [Header("Bullets")]
    public BezierBullet bezierBullet; //private Temp
    public DirectBullet directBullet; //private Temp

    protected override void Awake()
    {
        base.Awake();
        RandomInt(); //Temp

        for (int i = 0; i < 5; i++) //Temp
        {
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);
            Managers.Resource.Destroy(b);
        }
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
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        LookAt();
    }

    protected override void Attack()
    {
        directBullet.target = target;

        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);

        b.transform.parent = null;
        b.transform.position = transform.position;
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void LookAt()
    {
        if (target != null)
        {
            base.LookAt();
        }
    }

    private void LookAtGaze()
    {
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, Gaze(transform.position, gazeTarget));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, rotateSpeed * Time.deltaTime);
    }

    protected override void Death()
    {
        base.Death();
    } 

    private void RandomInt()
    {
        distance = Random.Range(5f, 7f);
    }
}
