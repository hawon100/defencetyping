using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : EnemyBase
{
    [Header("Bullet")]
    public DirectBullet directBullet;

    private Rigidbody2D rb2d;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 3; i++)
        {
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
            Managers.Resource.Destroy(b);
        }
    }

    protected override void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
    }


    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack() //First : Detected(), if no target : target set to centraltower
    {
        if (target != null)
        {
            //change target to isDetected, then if detected shoot the tower!
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);
            BulletBase s = b.GetComponent<BulletBase>();
            s.target = target;
            s.Init();
            b.transform.position = transform.position;
        }
        else
        {
            target = Managers.Game.target;
        }
    }

    protected override void Detected()
    {
        base.Detected();
    }

    protected override void Move()
    {
        if (!isMove) return;

        Detected();
        LookAt();

        rb2d.velocity = moveSpeed * Trace(transform.position, target.position).normalized; //Temp

        if (rb2d.velocity.sqrMagnitude <= 0.1f ||
            isDistance(transform.position, target.position, stopDistance))
        {
            rb2d.velocity = Vector2.zero;
            isMove = false;
        }
    }

    protected override void LookAt()
    {
        if (target == null) return;
        
        base.LookAt();
    }
}
