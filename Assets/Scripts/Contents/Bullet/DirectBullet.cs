using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectBullet : BulletBase
{
    [SerializeField] private GameObject boom;
    public override void Init()
    {
        base.Init();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Move();
    }

    protected override void Move()
    {
        if (target == null)
        {
            Managers.Resource.Destroy(gameObject);
            return;
        }

        //targetPos = target.position;
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    
        //if (Measure(targetPos - transform.position, 0.1f))
        //{
        //    target.GetComponent<TowerStat>().OnAttacked(1);
        //    target = null;
        //    trailRend.Clear();
        //    Managers.Resource.Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject b = Managers.Resource.Instantiate(boom, null);
        b.transform.position = transform.position;

        if (collision.gameObject.CompareTag("Tower")) Hit();
    }

    protected override void Hit()
    {
        target.GetComponent<TowerStat>().OnAttacked(1);
        target = null;
        base.Hit();
    }
}
