using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : EnemyBase
{
    [SerializeField] private Transform trans; //Temp
    [SerializeField] private int spawnCount; //Temp
    [SerializeField] private float radius;

    [Header("Ships")]
    public EnemyBase ship; //private Temp
    public DirectBullet directBullet; //private Temp

    private Vector3 spriteRotation;

    private bool isSpawn = true;

    private WaitForSeconds gazeOnTime = new WaitForSeconds(1f);
    private List<EnemyBase> curEnemys;

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < 5; i++) //Temp
        {
            GameObject s = Managers.Resource.Instantiate(ship.gameObject, transform.parent = null);
            Managers.Resource.Destroy(s);
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
        if (!isMove) Attack();

        if (isSpawn) Spawn();

        if (curEnemys.Count == 0) isSpawn = true;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        LookAt();
        Move();
    }

    protected override void Attack()
    {
        GameObject b = Managers.Resource.Instantiate(directBullet.gameObject, transform.parent = null);

        b.transform.parent = transform;
        b.transform.position = transform.position;
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < 360; i += 360 / spawnCount)
        {
            ship.gazeTarget.x = Mathf.Cos(i * Mathf.Deg2Rad);
            ship.gazeTarget.y = Mathf.Sin(i * Mathf.Deg2Rad);
            curEnemys.Add(ship);

            GameObject s = Managers.Resource.Instantiate(ship.gameObject, transform.parent = null);

            s.transform.position = transform.position;
        }

        isSpawn = false;

        yield return gazeOnTime;

        ship.target = target;
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void LookAt()
    {
        base.LookAt();
    }

    protected override void Death()
    {
        base.Death();
    }
}
