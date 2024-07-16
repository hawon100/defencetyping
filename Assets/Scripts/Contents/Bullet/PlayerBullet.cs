using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    private Vector2 moveVec; //Temp

    [SerializeField] private Transform arrow;

    public override void Init()
    {
        trailRend.Clear();
        base.Init();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        trailRend = GetComponent<TrailRenderer>();
        base.Start();
    }

    private void OnEnable()
    {
        trailRend.Clear();
    }

    private void OnDisable()
    {
        trailRend.Clear();
    }

    //public void test()
    //{
    //    if (target == null)
    //    {
    //        Managers.Resource.Destroy(gameObject);
    //        return;
    //    }
    //    moveVec = (target.position - transform.position).normalized;
    //}

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

        targetPos = target.position;
        //transform.Translate(moveVec * Time.deltaTime * speed);

        transform.rotation = Quaternion.Euler(0, 0, Gaze(transform.position, target.position));
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);

        if (target.gameObject.activeSelf) return;

        base.Hit();

        //if (Measure(targetPos - transform.position, 0.05f)) //This one has the Problem
        //{
        //    base.Hit();
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Hit();
    //    }
    //}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(triggerTag)) return;

        if (!target) return;

        if (!isDistance(transform.position, target.position, 1f)) return;

        Hit();
    }

    protected override void Hit()
    {
        target.gameObject.GetComponent<EnemyStatBase>().Damage(damage);
        target = null;
        base.Hit();
    }

    //Erase And Use isDistance Function.
    //protected override void Hit(GameObject hitObject)
    //{
    //    if (hitObject.GetComponent<EnemyBase>() != null)
    //    {
    //        hitObject.GetComponent<EnemyBase>().Damage(10);
    //    }

    //    target = null;
    //    Managers.Resource.Destroy(gameObject);
    //}
}
