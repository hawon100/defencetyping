using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : EnemyBase
{
    [Header("Ship")]
    [SerializeField] private EnemyBase ship;
    [SerializeField] private int amount;
    [SerializeField] private float radius;

    [Header("Bullet")]
    public DirectBullet directBullet;

    private Rigidbody2D rb2d;

    private Vector3 spawnVec;

    private bool isSpawn;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 5; i++)
        {
            GameObject s = Managers.Resource.Instantiate(ship.gameObject, transform.parent = null);
            Managers.Resource.Destroy(s);
            GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);
            Managers.Resource.Destroy(b);
        }
    }

    protected override void Start()
    {
        Init();
    }

    protected override void Init()
    {
        isSpawn = true;
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

    protected override void Attack()
    {
        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, null);

        b.transform.position = transform.position;

        if (!isSpawn) return;

        isSpawn = false;
        Spawn();
    }

    private void Spawn() 
    {
        for (int i = 0; i < 360; i += 360 / amount)
        {
            //targetPos.x = Mathf.Cos(i * Mathf.Deg2Rad) * 5f;
            //targetPos.y = Mathf.Sin(i * Mathf.Deg2Rad) * 5f;
            spawnVec.x = Mathf.Cos(i * Mathf.Deg2Rad) * radius;
            spawnVec.y = Mathf.Sin(i * Mathf.Deg2Rad) * radius;

            GameObject s = Managers.Resource.Instantiate(ship.gameObject, transform.parent = null);

            //s.transform.position = transform.position;
            s.transform.position = transform.position + spawnVec;
        }
    }

    protected override void Move()
    {
        if (!isMove) return;

        Detected();
        LookAt();

        rb2d.velocity = moveSpeed * Trace(transform.position, target.position);

        if (rb2d.velocity.sqrMagnitude <= 0.1f ||
            isDistance(transform.position, target.position, stopDistance))
        {
            rb2d.velocity = Vector2.zero;
            isMove = false;
        }
    }

    protected override void LookAt()
    {
        base.LookAt();
    }
}
